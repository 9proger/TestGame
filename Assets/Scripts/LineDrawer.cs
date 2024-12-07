using UnityEngine;
using System.Collections.Generic;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefab; // ������ �����
    private LineRenderer currentLine;
    private List<Vector2> points = new List<Vector2>();
    private bool isDrawing = false;
    private Transform player;

    public LayerMask groundLayer;
    public float castDistance;
    public Vector2 boxSize;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ��������������, ��� � ��������� ���� ��� "Player"
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPlayerOnGround())
        {
            StartDrawing();
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            UpdateLine();
        }

        if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            StopDrawing();
        }
    }

    private bool IsPlayerOnGround()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
        //return true; // �������� �� �������� ��������
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    private void StartDrawing()
    {
        isDrawing = true;
        points.Clear();
        currentLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
        points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        UpdateLineRenderer();
    }

    private void UpdateLine()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (points.Count == 0 || (Vector2.Distance(mousePos, points[points.Count - 1]) > 0.1f))
        {
            points.Add(mousePos);
            UpdateLineRenderer();
        }
    }

    private void UpdateLineRenderer()
    {
        currentLine.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            currentLine.SetPosition(i, points[i]);
        }
    }

    private void StopDrawing()
    {
        isDrawing = false;
        // ����� �������� ������ ��� �������� ����������� ������� �� ������ �����
        CreatePhysicsObject();
    }

    private void CreatePhysicsObject()
    {
        // ������ �������� ���������� �������� �� ������ ������������ �����
        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 start = points[i];
            Vector2 end = points[i + 1];

            // �������� ������ �������� ����� start � end
            GameObject stairSegment = new GameObject("StairSegment");
            stairSegment.transform.position = (start + end) / 2;

            // �������� ���������� Rigidbody2D � BoxCollider2D
            Rigidbody2D rb = stairSegment.AddComponent<Rigidbody2D>();
            rb.isKinematic = true; // ����� �������� �� ������ ��� ��������� ������

            BoxCollider2D collider = stairSegment.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(Vector2.Distance(start, end), 0.2f); // ��������� ������ �� ������ ����������
            collider.offset = new Vector2(0, collider.size.y / 2);
            stairSegment.transform.right = (end - start).normalized;
        }
    }
}

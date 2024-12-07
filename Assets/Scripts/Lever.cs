using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private Transform playerTransform;
    private Animator _animator;
    //public DoorSetActive Check;

    public LayerMask groundLayer;
    public Vector2 boxSize;
    public float castDistance;

    public bool levered;
    private bool isOpen;

    private IDoor door;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        door = doorGameObject.GetComponent<IDoor>();
        isOpen = levered;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && levered)
        {
            isOpen = !isOpen;
            _animator.SetBool("Open", isOpen);
            door.ToggleDoor();
        }
    }

    private void FixedUpdate()
    {
        var onGround = IsLevered();
        levered = onGround;
    }

    private bool IsLevered()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}

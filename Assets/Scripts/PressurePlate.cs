using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private Transform playerTransform;
    private Animator _animator;

    public LayerMask groundLayer;
    //public LayerMask groundLayer2;
    public Vector2 boxSize;
    public float castDistance;

    public bool levered;

    private IDoor door;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        door = doorGameObject.GetComponent<IDoor>();
    }

    //private void Update()
    //{
    //    if (levered)
    //    {
    //        door.ToggleDoor();
    //    }
    //}

    private void FixedUpdate()
    {
        var onGround = IsLevered();
        // Проверяем, изменилось ли состояние
        if (onGround != levered)
        {
            levered = onGround;
            if (levered)
            {
                door.ToggleDoor(); // Открываем дверь
            }
            else
            {
                door.ToggleDoor(); // Закрываем дверь
            }
        }
    }

    private bool IsLevered()
    {
        //if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer1) || Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer2))
        //{
        //    return true;

        //}
        //else
        //{
        //    return false;
        //}
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}

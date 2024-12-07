using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //private static readonly int VelocityX = Animator.StringToHash("VelocityX");
    //private static readonly int Stopping = Animator.StringToHash("Stopping");

    private Rigidbody2D _body;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public float speed = 5;
    public float acceleration = 20;
    //private bool _isStopping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private int levelcomplete;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //PlayerPrefs.SetInt("levelcomplete", 0);
    }

    private void Update()
    {
        //_animator.SetFloat(VelocityX, Mathf.Abs(_body.linearVelocityX));
        var currentVelocityX = _body.linearVelocityX;
        _animator.SetFloat("Velocity", Mathf.Abs(currentVelocityX));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var currentVelocityX = _body.linearVelocityX;
        var targetVelocityX = InputSystem.actions["Move"].ReadValue<Vector2>().x * speed;
        

        var mass = _body.mass;
        var acc = Mathf.Clamp((targetVelocityX - currentVelocityX) / Time.fixedDeltaTime, -acceleration, acceleration);

        _body.AddForceX(mass * acc);

        if (currentVelocityX > 0.1f && targetVelocityX < -0.1f || currentVelocityX < -0.1f && targetVelocityX > 0.1f)
        {
            //_isStopping = true;
            if (targetVelocityX > 0.1f) _spriteRenderer.flipX = false;
            if (targetVelocityX < -0.1f) _spriteRenderer.flipX = true;
        }
        else
        {
            //_isStopping = false;
            if (currentVelocityX > 0.1f) _spriteRenderer.flipX = false;
            if (currentVelocityX < -0.1f) _spriteRenderer.flipX = true;
        }
    }

    public void Victory()
    {
        //levelcomplete = PlayerPrefs.GetInt("levelcomplete");
        //_body.AddForceX(10);
        //if (SceneManager.GetActiveScene().buildIndex - 1 >= levelcomplete)
        //{
        //    levelcomplete = SceneManager.GetActiveScene().buildIndex - 1;
        //    _body.AddForceX(10);
        //}
        //PlayerPrefs.SetInt("levelcomplete", levelcomplete);
    }
}

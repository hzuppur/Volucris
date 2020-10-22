using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    bool onGround;
    [SerializeField]
    Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player is on the ground
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        // Basic movement
        if (Input.GetKey("a"))
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
           //_animator.Play("Run");
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("d"))
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
           // _animator.Play("Run");
            _spriteRenderer.flipX = true;

        }
        
        if(Mathf.Approximately(_rigidbody.velocity.y,0) && onGround){
            _animator.Play("Idle");
        }
        if(_rigidbody.velocity.y < 0){
            _animator.Play("Jump");
        }

        if (Input.GetButtonDown("Jump") && onGround)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _animator.Play("Jump");
        }

        if(Input.GetButtonDown("Fire1")){
            _animator.Play("Attack");
        }
    }
}

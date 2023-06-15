using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float speed=5f;

    private Rigidbody2D _rigidbody2D;//获得刚体
    private Animator _animator;//获得动画
    private Collider2D _collider2D;//获得碰撞体

    public bool isOnGround;//判断是否在地面
    public LayerMask groundLayer;//获得地面图层

    private float xVelocity;//获取x方向

    public float jumpVelocity=10f;//跳跃高度
    public float fallSpeed=2f;//下落速度
    private bool jumpRequest =false;

    public AudioSource music;
    public AudioClip jump;//添加跳跃音效

    private void Awake()
	{
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        jump = Resources.Load<AudioClip>("music/jump");
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D=GetComponent<Rigidbody2D>();
        _animator=GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity=Input.GetAxis("Horizontal_player1");
        
        if(isOnGround)
        {
            _animator.SetBool("jump",false);
            
            if(xVelocity>0)
            {
                _rigidbody2D.transform.eulerAngles=new Vector3(0f,0f,0f);
                _animator.SetBool("run",true);
            }

            if(xVelocity<0)
            {
                _rigidbody2D.transform.eulerAngles=new Vector3(0f,180f,0f);
                _animator.SetBool("run",true);
            }

            if(xVelocity<0.001f&&xVelocity>-0.001f)
            {
                _animator.SetBool("run",false);
            }
            
            if(Input.GetButtonDown("Jump_player1"))
            {
                music.clip=jump;
                music.Play();
                jumpRequest=true;//当点击跳跃
            }
        }else
        {
            _animator.SetBool("run",false);
            _animator.SetBool("jump",true);
        }
        
        Run();
        isOnGroundCheck();
    }

    void FixedUpdate()
    {
        if(_rigidbody2D.velocity.y<0)
        {
            _rigidbody2D.gravityScale=fallSpeed;
        }else
        {
            _rigidbody2D.gravityScale=1f;
        }
        if(jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up*jumpVelocity,ForceMode2D.Impulse);
            jumpRequest=false;
        }
    }

    void Run()
    {
        _rigidbody2D.velocity = new Vector2(
            xVelocity * speed,
            _rigidbody2D.velocity.y);
    }

    void isOnGroundCheck()
    {
        if (_collider2D.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }


}

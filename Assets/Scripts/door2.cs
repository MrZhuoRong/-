using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door2 : MonoBehaviour
{
    private Text textscore1;
    private float score=0;
    private bool isgetscore=false;
    public LayerMask doorLayer; 
    public LayerMask playerLayer; 
    private Collider2D _collider2D;//获得碰撞体

    public AudioSource music;
    public AudioClip getpoint;//添加得分音效

    private void Awake()
	{
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        getpoint = Resources.Load<AudioClip>("music/getpoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();

        textscore1 = GameObject.Find("player1ScoreText").GetComponent<Text>();//获取文本组件
    }

    // Update is called once per frame
    void Update()
    {
        if(isgetscore)
        {
            if (_collider2D.IsTouchingLayers(doorLayer))
            {
                music.clip=getpoint;
                music.Play();
                score+=1;
                textscore1.text=""+score;
                isgetscore=false;
            }
        }
        if (_collider2D.IsTouchingLayers(playerLayer))
        {
            isgetscore=true;
        }
    }

}

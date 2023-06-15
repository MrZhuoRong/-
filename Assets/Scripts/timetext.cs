using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timetext : MonoBehaviour
{
    private Text txtTimer;
    public float gametime;
    private Text textscore1;
    private Text textscore2;
    private float score1=0;
    private float score2=0;
 
    private void Start()
    {
        txtTimer = this.GetComponent<Text>();//获取文本组件
        textscore2 = GameObject.Find("player2ScoreText").GetComponent<Text>();//获取文本组件
        textscore1 = GameObject.Find("player1ScoreText").GetComponent<Text>();//获取文本组件
    }
 
    private void Update()
    {
        score1=float.Parse(textscore1.text);
        score2=float.Parse(textscore2.text);
        if (gametime > 0)
        {
            gametime = gametime - Time.deltaTime;
            if (gametime / 60 < 1)//当小于一分钟
            {
                if (gametime < 11)//最后十秒变红
                {
                    txtTimer.color = Color.red;
                }
                txtTimer.text = string.Format("00:{0:d2}", (int)gametime % 60);
            }
            else
            {
                txtTimer.text = string.Format("{0:d2}:{1:d2}", (int)gametime / 60, (int)gametime % 60);
            }
        }
        else
        {
            txtTimer.text = "00:00";
            txtTimer.color = Color.red;
            if(score1>score2)
            {
                SceneManager.LoadScene("Over1win");
            }
            if(score1<score2)
            {
                SceneManager.LoadScene("Over2win");
            }
            if(score1==score2)
            {
                SceneManager.LoadScene("tie");
            }
        }
        
    }

}

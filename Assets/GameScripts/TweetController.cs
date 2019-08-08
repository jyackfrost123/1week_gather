using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetController : MonoBehaviour
{
    // Start is called before the first frame update

    public int UseEraser;
    public int numNerikesi;

    EventController ui;
    GameObject player;

    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<EventController>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoTweet(){
        //naichilab.UnityRoomTweet.Tweet ("eraser_dustget", "先生！僕のねりけしね！"+( (ui.eraserUsed/700) +1).ToString()+"個消しゴムを使って、"+ui.score.ToString()+"個の消しかすを集めたんだよ！", "unityroom", "unity1week");
        
        StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("先生！僕のねりけしね！"+( (ui.eraserUsed/700) +1).ToString()+"個消しゴムを使って、"+ui.score.ToString()+"個の消しかすを集めたんだよ！"));  
        player.transform.position = new Vector3(-10.0f,2.5f,-944.0f);
    }


    public void GoRankingResult(){
       naichilab.RankingLoader.Instance.SendScoreAndShowRanking (ui.score);
    }
}

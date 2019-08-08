using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameStart = false;

    public bool gameEnd = false;

    public int score;
    public int eraserUsed;

    public float startTime;

    public float timeLimit;

    bool check = false;


    Text scoretext;
    Text eraserUsedText;
    Text gameoverText;
    Text timeLimitText;

    BGMController bgm;
    SEController se;

    GameObject GameOverButton;

    void Start(){
        scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
        eraserUsedText = GameObject.Find("eraserUsedText").GetComponent<Text>();
        gameoverText = GameObject.Find("gameoverText").GetComponent<Text>();
        timeLimitText = GameObject.Find("timeLimitText").GetComponent<Text>();
        bgm = GameObject.Find("BGMController").GetComponent<BGMController>();
        se = GameObject.Find("SEController").GetComponent<SEController>();
        GameOverButton = GameObject.Find("GameOverButton");
        GameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(!gameStart){

            if (startTime > 1)
            {
                startTime -= 1.0f * Time.deltaTime;
                gameoverText.text = ((int)startTime).ToString();
            }
            else
            {
                gameStart = true;
            }

        }else{

            if(startTime >= 0){
                  gameoverText.text = "Start!";
                  //startTime -= 1.0f * Time.deltaTime;//ここ
                  startTime -= 1.0f * Time.deltaTime;
            }else{
                  gameoverText.text = "";
            }


            if(timeLimit > 0){
              timeLimit -= 1.0f * Time.deltaTime;
            }else{
              timeLimit = 0;
              gameEnd = true;
            }
        }

        scoretext.text = "ねりねりしたかす:" + score.ToString();
        eraserUsedText.text = "つかったケシゴム:" + ( (eraserUsed/800)+1 ).ToString()+"こ";
        timeLimitText.text = "のこりじかん:" + ((int)timeLimit).ToString() + "びょう";

        if(gameEnd){
            bgm.FadeOut(2);
            if (se.sourceNumber != 2)
            {
                se.StopSE();
                se.ChangeSE(2);
                se.StartSE();
            }

            if(!check){
                    gameoverText.text = "ねりねり終了!";
            }



            if(GameOverButton.activeSelf == false){
                GameOverButton.SetActive(true);
            }



            /*if(!check){
              
              //StartCoroutine( checkDast(score) );
             


              check = true;
            }*/


        }
    }

    public void AddScore(int point){
        score += point;
    }

    public void UseEraser(){
        eraserUsed+=2;
    }

    public void GameStart(){
        gameStart = true;
    }

    public void GameEnd(){
        gameStart = false;
        //
    }


    /*public IEnumerator checkDast(int score){
        
        //gameoverText.text = "ねりねり終了!";
        yield return new WaitForSeconds (5.0f);

        gameoverText.text = "";
        
        yield return null;
    }*/

}

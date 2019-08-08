using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
    // Use this for initialization

    Vector3 prePosition;

    Vector3 prePrePosition;//前前フレームの位置

    Vector3 nowPosition;

    private Vector3 hosei;


    bool IsprevSpdPositionX;
    bool IsnowSpdPositionX;

    bool IsprevSpdPositionY;
    bool IsnowSpdPositionY;

    public GameObject[] eraser;
    public GameObject nowEraser;

    public GameObject kneaded;

    Vector3 preSpeed;
    Vector3 nowSpeed;

    EventController ui;
    EraserCrumbController dust;
    public int point;

    public bool collect = false;


    SEController se;

    bool dustMode = false;
    bool eraserMode = true;

    void Start () {
        ui = GameObject.Find("Canvas").GetComponent<EventController>();
        dust = GameObject.Find("EraserCrumbController").GetComponent<EraserCrumbController>();
        eraser[0].SetActive(true);
        nowEraser = eraser[0];
        se = GameObject.Find("SEController").GetComponent<SEController>();
    }
	
	// Update is called once per frame
	void Update () {

        if(ui.eraserUsed % 100 == 0 && ui.eraserUsed !=0){
            cycleEraser(ui.eraserUsed / 100 % (eraser.Length) );
        }



		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 10f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
		// ワールド座標に変換されたマウス座標を代入
		//gameObject.transform.position = screenToWorldPointPosition;
        hosei = screenToWorldPointPosition;
        //eraser.transform.position = screenToWorldPointPosition;


        hosei.y = screenToWorldPointPosition.y + 0.5f;
        hosei.x = screenToWorldPointPosition.x + 1.5f;
        gameObject.transform.position = hosei;


        nowPosition = transform.position;
        //owPosition.y = transform.position.y + 1.0f;

        preSpeed = prePrePosition - prePosition;
        nowSpeed = nowPosition - prePosition;


        if(preSpeed.x > 0){
            IsprevSpdPositionX = true;
        }else{
            IsprevSpdPositionX = false;
        }

		if(nowSpeed.x > 0){
            IsnowSpdPositionX = true;
        }else{
            IsnowSpdPositionX = false;
        }


        if(preSpeed.y > 0){
            IsprevSpdPositionY = true;
        }else{
            IsprevSpdPositionY = false;
		}

		if(nowSpeed.y > 0){
            IsnowSpdPositionY = true;
		}else{
            IsnowSpdPositionY = false;
		}


		if( ( (IsnowSpdPositionX != IsprevSpdPositionX) || (IsnowSpdPositionY != IsprevSpdPositionY) )　&& (ui.gameEnd != true) ){
            //消す



            //Debug.Log("Yes!!!!");
           //if( (Input.GetMouseButton(0)) && dustMode == false ){
             //if( eraserMode == true && dustMode == false){
            if( (Input.GetMouseButton(0)) ){
                if (ui.gameStart == true && ui.gameEnd == false){
                    nowEraser.SetActive(true);
                    kneaded.SetActive(false);
                    dust.MakeEraserCrumbs(nowEraser, (ui.eraserUsed / 700) + 1);
                    ui.UseEraser();
                    collect = false;
                    if (!se.playingSE.isPlaying)
                    {
                        se.StartSE();
                    }
                }
            //}else if( dustMode == true && eraserMode == false){
            // }else if( Input.GetMouseButton(1) || (dustMode == true && Input.GetMouseButton(0))){
            }else if( Input.GetMouseButton(1) ){
                if (ui.gameStart == true && ui.gameEnd == false){
                    nowEraser.SetActive(false);
                    kneaded.SetActive(true);
                    collect = true;
                }

                if(se.playingSE.isPlaying){
                    se.StopSE();
                }
            }else{
                collect = false;
                if(se.playingSE.isPlaying){
                    se.StopSE();
                }
            }


        }else{
            collect = false;
            //Debug.Log("Stop!!!!");
        }

        if(ui.gameEnd == true){
           //nowEraser.SetActive(false);
           //kneaded.SetActive(true);
           nowEraser.SetActive(true);
           kneaded.SetActive(false);
        }

        prePrePosition = prePosition;
        prePosition = nowPosition;


      /*else if(Input.GetMouseButton(1)){
                if (ui.gameStart == true && ui.gameEnd == false){
                    nowEraser.SetActive(false);
                    kneaded.SetActive(true);
                }
            }
       */
    }


    public void cycleEraser(int i){
        eraser[i].SetActive(true);
        nowEraser = eraser[i];
        if(i != 0){
          eraser[i-1].SetActive(false);
        }else{
          eraser[eraser.Length - 1].SetActive(false);
          //ui.useEraser();
        }

    }

    public void setEraser(){
     if (ui.gameEnd != true) {
        eraserMode = true;
        dustMode = false;
     }

    }

    public void setDust(){
     if (ui.gameEnd != true){
          dustMode = true;
          eraserMode = false;
      }
    }

}
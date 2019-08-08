using UnityEngine;
using System.Collections;

public class OpninghandsController : MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
    // Use this for initialization

    private Vector3 hosei;

    Vector3 prePosition;

    Vector3 prePrePosition;//前前フレームの位置

    Vector3 nowPosition;


    bool IsprevSpdPositionX;
    bool IsnowSpdPositionX;

    bool IsprevSpdPositionY;
    bool IsnowSpdPositionY;

    public GameObject[] eraser;
    public GameObject nowEraser;

    public GameObject kneaded;

    Vector3 preSpeed;
    Vector3 nowSpeed;
    EraserCrumbController dust;
    public int point;
    public int opningusedEraser = 0;

    SEController se;




    void Start () {
        dust = GameObject.Find("EraserCrumbController").GetComponent<EraserCrumbController>();
        eraser[0].SetActive(true);
        nowEraser = eraser[0];
        se = GameObject.Find("SEController").GetComponent<SEController>();
    }

    // Update is called once per frame
    void Update(){

        
        if(opningusedEraser % 100 == 0 && opningusedEraser !=0){
            cycleEraser(opningusedEraser / 100 % eraser.Length);
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
        hosei.y = screenToWorldPointPosition.y + 0.5f;
        hosei.x = screenToWorldPointPosition.x + 1.5f;
        gameObject.transform.position = hosei;
        //eraser.transform.position = screenToWorldPointPosition;

        nowPosition = transform.position;
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


        if( (IsnowSpdPositionX != IsprevSpdPositionX) || (IsnowSpdPositionY != IsprevSpdPositionY)　){
            //消す
            //Debug.Log("Yes!!!!");
            if((Input.GetMouseButton(0))){
                    nowEraser.SetActive(true);
                    kneaded.SetActive(false);
                    dust.MakeEraserCrumbs(nowEraser,1);
                    opningusedEraser += 2;
                  if (!se.playingSE.isPlaying)
                    {
                        se.StartSE();
                    }
            }else if(Input.GetMouseButton(1)){
                    nowEraser.SetActive(false);
                    kneaded.SetActive(true);
                if(se.playingSE.isPlaying){
                    se.StopSE();
                }
            }else{
                if(se.playingSE.isPlaying){
                    se.StopSE();
                }
            }


        }else{

        }

        prePrePosition = prePosition;
        prePosition = nowPosition;
  }


    public void cycleEraser(int i){
        eraser[i].SetActive(true);
        nowEraser = eraser[i];
        if(i != 0){
          eraser[i-1].SetActive(false);
        }else{
          eraser[eraser.Length - 1].SetActive(false);
        }

    }

}

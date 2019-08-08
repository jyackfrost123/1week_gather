using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update

    public static BGMController bgm;
    public static SEController se;
    
    void Start()
    {
        bgm = GameObject.Find("BGMController").GetComponent<BGMController>();
        se = GameObject.Find("SEController").GetComponent<SEController>();
    }

    // Update is called once per frame
    public static void StartSE(int SENumber){
        se.ChangeSE(SENumber);
    }

    public static void StartBGM(int BGMNum){
        bgm.ChangeBGM(BGMNum);
    }
}

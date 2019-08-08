using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour{

    public AudioSource playingSE;

    public int sourceNumber = 0;

    public AudioClip[] SELayout;


    void Awake(){
        playingSE = GetComponent<AudioSource>();
        ChangeSE(0);
    }

    void Start(){
         //DontDestroyOnLoad(this);
    }


    public void ChangeSE(int SENumber){
        AudioClip newSE = SELayout[SENumber];
        if(!playingSE.isPlaying){
         this.playingSE.clip = newSE;
         this.playingSE.volume = 0.5f;
         sourceNumber = SENumber;
       }
    }

    public void StartSE(){
        playingSE.Play();
    }

    public void StopSE(){
        playingSE.Stop();
    }

}

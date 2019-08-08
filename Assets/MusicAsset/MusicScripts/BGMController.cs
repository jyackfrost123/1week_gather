using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

    /*https://qiita.com/lycoris102/items/5d5359b2015a8fdebaaa */

    bool changing = false;

    int musicNumber = 0;

    public float fadeTime;

    public float musicVolume;


    private AudioSource playingSource;


    public AudioClip[] musicLayout;

    private void Awake ()
    {

        playingSource = GetComponent<AudioSource>();
        playingSource.clip = musicLayout[musicNumber];
    }

    void Start(){
        playingSource.volume = musicVolume;
        playingSource.Play();//テスト用再生
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update(){

        /*if (Input.GetKeyDown(KeyCode.A)){
            musicNumber++;
            if(musicNumber >= musicLayout.Length){
                musicNumber = 0;
            }
            ChangeBGM(musicLayout[musicNumber], fadeTime);
        }*/ //テスト用


    }

    //指定時間フェードアウト、指定時間フェードイン
    //主に呼び出して使われるべき関数がここ
    public void ChangeBGM(int BGMNum){
        AudioClip nextMusic = musicLayout[BGMNum];
        if(!changing){
         StartCoroutine( ChangeMusic(nextMusic, fadeTime) );
        }
    }


     public IEnumerator ChangeMusic(AudioClip nextMusic,float time){
        changing = true;
        yield return null;

        while(this.playingSource.volume > 0){
             FadeOut(time);
            yield return null;
         }

          this.playingSource.Stop();
          yield return null;

          this.playingSource.clip = nextMusic;
          yield return null;

         while(this.playingSource.volume < 0.5f){//BGMなので音量半分くらい
             FadeIn(time);
             yield return null;
         }

        changing = false;
        yield return null;
    }

    public void FadeOut(float time){
        this.playingSource.volume -= 1.0f * (Time.deltaTime / time);
    }


    public void FadeIn(float time){
       if(!playingSource.isPlaying){
         this.playingSource.volume = 0.0f;
         playingSource.Play();
       }

       //this.playingSource.volume += (1.0f/time);
       this.playingSource.volume += 1.0f * (Time.deltaTime / time);
    }

}

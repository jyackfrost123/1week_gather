using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knededController : MonoBehaviour
{

    EventController ui;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<EventController>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(0.5f + 0.2f * (ui.score / 100), 0.5f + 0.2f *(ui.score/ 100), 0.5f + 0.2f *(ui.score/ 100));
    }


    void OnTriggerEnter2D( Collider2D coll) {
        if(player.collect == true){
          Destroy (coll.gameObject);
          ui.AddScore(1);
        }

    }


}

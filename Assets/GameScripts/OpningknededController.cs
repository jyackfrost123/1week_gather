
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpningknededController : MonoBehaviour
{

    OpninghandsController player;

    void Start()
    {
        player = GameObject.Find("player").GetComponent<OpninghandsController>();
    }

    // Update is called once per frames
    void Update()
    {
        this.transform.localScale = new Vector3(0.5f + 0.2f * (player.opningusedEraser / 100), 0.5f + 0.2f *(player.opningusedEraser/ 100), 0.5f + 0.2f *(player.opningusedEraser/ 100));
    }


    void OnTriggerEnter2D( Collider2D coll) {

        if(coll.gameObject.tag != "OpningObject"){
            Destroy (coll.gameObject);
        }
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpningEraserController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D( Collider2D coll) {

        if(coll.gameObject.tag == "OpningObject"){
            Debug.Log("Yes!");
            float changeRed = 1.0f;
            float changeGreen = 1.0f;
            float cahngeBlue = 1.0f;
            float cahngeAlpha = 0.5f;
            // 元の画像の色のまま、半透明になって表示される。
            coll.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
        }

    }

}

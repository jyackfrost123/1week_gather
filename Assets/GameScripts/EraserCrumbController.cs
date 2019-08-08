using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserCrumbController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] eraserCrumbs;

    GameObject player;
    //EventController ui;

    void Start()
    {
        player = GameObject.Find("player");
        //ui = GameObject.Find("gameoverText").GetComponent<EventController>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void MakeEraserCrumbs( GameObject eraser, int n){
        for (int i = 0; i < n; i++){
            GameObject crumb = Instantiate(eraserCrumbs[Random.Range(0, eraserCrumbs.Length)], new Vector3(eraser.transform.position.x - 0.25f, eraser.transform.position.y + Random.Range(-1.0f, -0.5f), eraser.transform.position.z + 1.0f), Quaternion.identity);
            crumb.transform.parent = this.transform;
        }

    }
}

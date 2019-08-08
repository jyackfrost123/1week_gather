using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calcCOntroller : MonoBehaviour
{

    const int LOOP_MAX =5;
    Queue queue = new Queue();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LOOP_MAX; i++){
            queue.Enqueue(i);
            if(i%2 == 0){
                queue.Enqueue(i*2);
            }

            Debug.Log( "今のカウントは:"+(queue.Count).ToString());

        }

                Debug.Log( "今のカウントは:"+(queue.Count).ToString());


        for (int i = 0; i < queue.Count; i++)
        {
            Debug.Log( (queue.Dequeue() ).ToString());
        }

                Debug.Log( "今のカウントは:"+(queue.Count).ToString());



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

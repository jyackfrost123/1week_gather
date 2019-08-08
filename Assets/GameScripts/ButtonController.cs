using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* public void ButtonClicked () {
        SceneManager.LoadScene("BattleScene");
	}*/

    public void GoGameScene(){
         SceneManager.LoadScene("GameScene");
    }

    public void GoOpning(){
        SceneManager.LoadScene("Opning");
    }

    public void GoRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0);
    }

}

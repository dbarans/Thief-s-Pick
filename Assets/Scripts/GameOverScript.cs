using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public Target targetScript;
    private void OnMouseDown()
    {
        if(targetScript.gameIsOver)
        {
            targetScript.gameIsOver = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}

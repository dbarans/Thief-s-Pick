using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
        if(manager.gameIsOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}

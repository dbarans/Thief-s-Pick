using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PointerScript pointerScript;
    public GameObject circleObject;
    public Target targetScript;
    public bool isClicked = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public bool gameIsOver = false;

    private void Start()
    {
        Application.targetFrameRate = 144;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            if (targetScript.isCollision)
            {
                isClicked = true;
                score++;
                scoreText.text = score.ToString();
                pointerScript.ChangeDirection();
                pointerScript.IncreaseSpeed();
                targetScript.MoveToRandomPosition();
            }
            else
            {
                GameOver();
            }  
        }
        else
        {
            
        }
    }
    
    public void GameOver()
    {
        gameIsOver = true;
        pointerScript.gameObject.SetActive(false);
        targetScript.gameObject.SetActive(false);
        circleObject.SetActive(false);
        pointerScript.speed = 0;
    }

    
}


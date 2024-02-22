using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public PointerScript pointerScript;
    public GameObject circleObject;
    public Target targetScript;
    public GameObject pointer;
    public bool isClicked = false;
    private int score = 0;
    private int savedScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI pointsText;
    public bool gameIsOver = false;
    public int level = 1;
    public int pointsToLevelUp = 1;
    private Vector3 startingPointerPos;
    private Color backgroundColor;
    public bool isRestarted = false;


    private void Start()
    {
        backgroundColor = Camera.main.backgroundColor;
        Application.targetFrameRate = 144;
        targetScript.MoveToRandomPosition();
        Time.timeScale = 1f;
        startingPointerPos = pointer.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRestarted)
        {

            if (targetScript.isCollision)
            {
                isClicked = true;
                pointsToLevelUp--;
                pointsText.text = pointsToLevelUp.ToString();
                score++;
                scoreText.text = score.ToString();
                pointerScript.ChangeDirection();
                pointerScript.IncreaseSpeed();
                targetScript.MoveToRandomPosition();

                if (pointsToLevelUp == 0)
                {
                    LevelUp();
                    pointsToLevelUp = level;
                }
            }
            else
            {
                GameOver();
            }
        } 
        else if (isRestarted)
        {
            isRestarted = false;
        }
    }

    public void GameOver()
    {
        isClicked = false;
        gameIsOver = true;
        Time.timeScale = 0f;
        pointerScript.gameObject.SetActive(false);
        targetScript.gameObject.SetActive(false);
        circleObject.SetActive(false);
        pointerScript.speed = 0;
        ColorChange();
    }
    public void ColorChange()
    {
        Camera.main.backgroundColor = new Color(0.8f, 0.4f, 0.4f);
    }

    public void LevelUp()
    {
        level++;
        savedScore = score;
        pointsToLevelUp = level;
        levelText.text = "Level: " + level.ToString();
        pointsText.text = pointsToLevelUp.ToString();
        pointerScript.speed = pointerScript.startingSpeed;
    }

    public void RestartLvl()
    {
        isRestarted = true;
        gameIsOver = false;
        Time.timeScale = 1f;
        circleObject.SetActive(true);
        Camera.main.backgroundColor = backgroundColor;

        //resetting the pointer
        pointerScript.gameObject.SetActive(true);
        pointer.transform.position = startingPointerPos;
        pointerScript.speed = pointerScript.startingSpeed;
        pointerScript.direction = -1;
        pointer.transform.rotation = (new Quaternion(0, 0, 0, 0));

        //resetting the score
        score = savedScore;
        scoreText.text = score.ToString();
        pointsToLevelUp = level;
        pointsText.text = pointsToLevelUp.ToString();

        //resetting the target
        targetScript.gameObject.SetActive(true);
        targetScript.MoveToRandomPosition();


     
    }
    public void RestartGame()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene("Game");
        
    }
}

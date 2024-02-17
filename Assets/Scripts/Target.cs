using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public RotateAround rotateAroundScript;
    public GameObject circleObject;
    public float radius;
    private bool isCollision = false;
    private bool isClicked = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int speedChange = 1;
    public bool gameIsOver = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCollision)
            {
                isClicked = true;
                score++;
                scoreText.text = score.ToString();
                IncreaseSpeed();
                MoveToRandomPosition();

            } else 
            {
                GameOver();
            }
        }
    }
    private void MoveToRandomPosition()
    {
        float minDistance = 3.0f;
        Vector3 newPosition;

        do
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float newX = circleObject.transform.position.x + radius * Mathf.Cos(angle);
            float newY = circleObject.transform.position.y + radius * Mathf.Sin(angle);
            newPosition = new Vector3(newX, newY, 0f);
        } while (Vector3.Distance(newPosition, transform.position) < minDistance);

        transform.position = newPosition;
        rotateAroundScript.speed = -rotateAroundScript.speed;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pointer"))
        {
            isCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
        if (isClicked)
        {
            isClicked = false;
        } else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        gameIsOver = true;
        gameObject.SetActive(false);
        circleObject.SetActive(false);
        rotateAroundScript.speed = 0;
    }

    public void IncreaseSpeed()
    {
        if(rotateAroundScript.speed > 0f)
        {
            rotateAroundScript.speed += speedChange;
        } else
        {
            rotateAroundScript.speed -= speedChange;
        }
    }
}


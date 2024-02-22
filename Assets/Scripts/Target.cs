using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public GameObject circleObject;
    public GameObject pointer;
    public GameManager manager;
    public float radius;
    public bool isCollision = false;
    public bool isClicked = false;





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
        if (manager.isClicked)
        {
            manager.isClicked = false;
        }
        else
        {
            manager.GameOver();
        }

    }

    public void MoveToRandomPosition()
    {
        float minDistance = 2.0f;
        Vector3 newPosition;

        do
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float newX = circleObject.transform.position.x + radius * Mathf.Cos(angle);
            float newY = circleObject.transform.position.y + radius * Mathf.Sin(angle);
            newPosition = new Vector3(newX, newY, 0f);
        } while (Vector3.Distance(newPosition, pointer.transform.position) < minDistance);

        transform.position = newPosition;
    }
}

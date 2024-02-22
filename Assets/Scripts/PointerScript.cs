using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    public GameObject rotatingObj;
    public int startingSpeed;
    public int speed;
    public int speedChange = 5;
    [HideInInspector] public int direction = -1;

    void Update()
    {
        transform.RotateAround(rotatingObj.transform.position, Vector3.forward, speed * direction * Time.deltaTime);
    }
    public void IncreaseSpeed()
    {
        speed += speedChange;
    }

    public void ChangeDirection()
    {
        if (direction == -1)
        {
            direction = 1;
        } else
        {
            direction = -1;
        }
    }

}

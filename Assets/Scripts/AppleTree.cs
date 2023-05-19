using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 5f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.04f;
    public float secondsBetweenAppleDrops = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
         // Dropping apples every second
         
          InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);    
    }
    // ReSharper disable Unity.PerformanceAnalysis
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    // Update is called once per frame
    void Update()
    {
            // Basic Movement
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            
            // Changing Direction
            if (pos.x < -leftAndRightEdge)
            {
                speed = Mathf.Abs(speed); // Move right
            }
            else if (pos.x > leftAndRightEdge)
            {
                speed = -Mathf.Abs(speed); // Move left
            } 
    }

    private void FixedUpdate()
    {
        // Changing Direction Randomly is now time-based because of FixedUpdate()
        if (UnityEngine.Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change direction
        }
    }
}

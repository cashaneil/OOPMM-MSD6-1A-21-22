using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 scrollOffset;

    void Start()
    {
        startPosition = transform.position; //define current background container's position as the start position

        //define the maximum scroll position for the current level's background
        switch (GameData.CurrentLevel)
        {
            case GameData._currentLevel.Level1:
                scrollOffset = new Vector3(-36.0f, startPosition.y, startPosition.z);
                break;
            case GameData._currentLevel.Level2:
                scrollOffset = new Vector3(-36.0f, startPosition.y, startPosition.z);
                break;
            case GameData._currentLevel.Level3:
                scrollOffset = new Vector3(-46.8f, startPosition.y, startPosition.z);
                break;
        }

        //if (GameData.CurrentLevel == 1)
        //{
        //    scrollOffset = new Vector3(-36.0f, startPosition.y, startPosition.z);
        //}
        //else if (GameData.CurrentLevel == 2)
        //{
        //    scrollOffset = new Vector3(-36.0f, startPosition.y, startPosition.z);
        //}
        //else if (GameData.CurrentLevel == 3)
        //{
        //    scrollOffset = new Vector3(-46.8f, startPosition.y, startPosition.z);
        //}
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, scrollOffset, 0.5f * Time.deltaTime); //on every frame, move towards the max scroll pos

        if (transform.position == scrollOffset) //if current pos is max scroll pos, reset it back to start pos
        {
            transform.position = startPosition;
        }
    }
}

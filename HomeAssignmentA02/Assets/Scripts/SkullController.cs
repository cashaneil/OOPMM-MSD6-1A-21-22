using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    Animator skull;
    
    // Start is called before the first frame update
    void Start()
    {
        skull = GetComponent<Animator>();
        ChangeState(); //update state at start of game
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState(); //update state during game
    }

    void ChangeState()
    {
        if (GameData.Kills >= 10)
        {
            skull.SetBool("floatSkull2", true);
        }
        if (GameData.Kills >= 20)
        {
            skull.SetBool("floatSkull3", true);
        }
        if (GameData.Kills >= 30)
        {
            skull.SetBool("floatSkull4", true);
        }
    }
}

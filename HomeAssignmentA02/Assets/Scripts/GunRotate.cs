using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    //to be able to attach the GunTip game object's transform.position in it
    Transform GunTip;
    //Blast1 prefab
    GameObject Blast1;
    GameObject Blast2;
    GameObject Blast3;
    Coroutine blastCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        GunTip = this.gameObject.transform.GetChild(0);

        Blast1 = Resources.Load("L1Blast") as GameObject;
        Blast2 = Resources.Load("L2Blast") as GameObject;
        Blast3 = Resources.Load("L3Blast") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //calculating mouse pos RELATIVE to the gun pos by substracting gun pos by mouse pos
        Vector3 mouselook = this.transform.position - GameData.MousePos;

        Quaternion newrotation = Quaternion.LookRotation(mouselook, Vector3.forward);
        newrotation.x = 0f; //reset back any x rotation to 0f
        newrotation.y = 0f; //reset back any y rotation to 0f

        //rotate gun and add slerp
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 8);

        if (Input.GetButtonDown("Fire1"))
        {
            blastCoroutine = StartCoroutine(repeatBlast());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(blastCoroutine);
        }
    }

    IEnumerator repeatBlast()
    {
        //level 1 values
        GameObject blastToSpawn = Blast1;
        float waitTime = 0.5f;

        if (GameData.CurrentLevel == 2)
        {
            blastToSpawn = Blast2;
            waitTime = 0.3f;
        }
        else if (GameData.CurrentLevel == 3)
        {
            blastToSpawn = Blast3;
            waitTime = 0.1f;
        }

        while (true)
        {
            GameObject spawnedBlast = Instantiate(blastToSpawn, GunTip.position, Quaternion.identity);
            //blast must be given a direction velocity
            //in this case it is from the player to the mouse position
            //run BlastToTarget with parameter of mouse pos
            spawnedBlast.SendMessage("BlastToTarget", GameData.MousePos);
            yield return new WaitForSeconds(waitTime);
        }
    }
}

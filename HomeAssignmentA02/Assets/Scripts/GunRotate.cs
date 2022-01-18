using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    //to be able to attach the GunTip game object's transform.position in it
    Transform GunTip;
    [SerializeField] List<GameObject> BlastList;
    Coroutine blastCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        GunTip = this.gameObject.transform.GetChild(0);
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
        int blastToSpawn = 0;
        float waitTime = 0.5f;

        switch (GameData.CurrentLevel)
        {
            case GameData._currentLevel.Level2:
                blastToSpawn = 1;
                break;

            case GameData._currentLevel.Level3:
                blastToSpawn = 2;
                break;
        }

        while (true)
        {
            GameObject spawnedBlast = Instantiate(BlastList[blastToSpawn], GunTip.position, Quaternion.identity);
            //blast must be given a direction velocity
            //in this case it is from the player to the mouse position
            //run BlastToTarget with parameter of mouse pos
            spawnedBlast.SendMessage("BlastToTarget", GameData.MousePos);
            yield return new WaitForSeconds(waitTime);
        }
    }
}

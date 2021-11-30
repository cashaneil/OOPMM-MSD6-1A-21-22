using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCannon : MonoBehaviour
{
    Transform CannonTip; //variable of type transform to be able to attach the CannonTip game object's transform.position in it
    GameObject smallbullet;
    GameObject largebullet;

    // Start is called before the first frame update
    void Start()
    {
        //get the transform of a child of the Cannon GameObject according to the index number provided
        //childs in game objects have index numbers from 0 onwards
        //CannonTip is the only child of Cannon so it is 0
        CannonTip = this.gameObject.transform.GetChild(0);

        smallbullet = Resources.Load("SmallBullet") as GameObject;
        largebullet = Resources.Load("LargeBullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //calculating mouse pos RELATIVE to the cannon pos (ie. the difference in dist between them) by substracting cannon pos by mouse pos
        Vector3 mouselook = this.transform.position - GameData.MousePos;

        //Since Unity is actually 3D based, if we want an object to rotate in 2D, it needs to rotate AROUND the Z axis, which in Unity is Vector3.forward
        //newrotation specifies new rotation coordinated for the cannon to be set to
        //LookRotation first takes the rotation coordinates to rotate to (mouselook), then around what axis does it rotate to does coordinates
        Quaternion newrotation = Quaternion.LookRotation(mouselook, Vector3.forward);
        newrotation.x = 0f; //reset back any x rotation to 0f since we only want to rotate around the z axis
        newrotation.y = 0f; //reset back any y rotation to 0f since we only want to rotate around the z axis
        
        //this.transform.rotation = newrotation; //no slerp

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 6);

        //firing bullet
        if (Input.GetButtonDown("Fire1")) {
            //it is the connon's role to spawn the bullet, but once the bullet is spawned, it is the SmallBullet script's role to control it
            GameObject mysmallbullet = Instantiate(smallbullet, CannonTip.position, Quaternion.identity);
            //so setting the velocity should be moved to the SmallBullet script
            //mysmallbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 4f);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject mylargebullet = Instantiate(largebullet, CannonTip.position, Quaternion.identity);
        }
    }
}

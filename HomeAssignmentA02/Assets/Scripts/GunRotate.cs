using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer laser;

    private void Start()
    {
        laser = GetComponent<LineRenderer>();//Assigning the variable laser to the Line Renderer component of the gameobject.
        laser.enabled = !laser.enabled;//Disabling the laser at start.
    }

    void Update ()
    {
        if (Input.GetMouseButton(1))//When right click is pressed it enables/disables the laser.
        {
            laser.enabled = true;
        }
        else
        {
            laser.enabled = false;
        }
    }
}

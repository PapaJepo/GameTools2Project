using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer laser;

    private void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = !laser.enabled;
    }

    void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            laser.enabled = !laser.enabled;
        }
    }
}

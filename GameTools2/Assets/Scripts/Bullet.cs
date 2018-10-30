using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "zombie")
        {
            GameObject.Find("zombie").GetComponent<Zombie>().health -= damage;
            Destroy(gameObject);
        }

    }
}

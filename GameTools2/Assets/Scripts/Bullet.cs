using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10f; //I'm setting the damage the bullet does.

    void OnTriggerEnter(Collider collider) //If the object the bullet script is attached to collides with an onject with trigger collider it calls this function. 
    {
        if (collider.gameObject.name == "zombie")//If the object has the name zombie the script finds the zombies script and deals damage to its health.
        {
            GameObject.Find("zombie").GetComponent<Zombie>().health -= damage;
            Destroy(gameObject); //This destroys the gameobject the bullet script is attached to.
        }
        if (collider.gameObject.name == "zombie(Clone)")//If the object has the name zombie the script finds the zombies script and deals damage to its health.
        {
            GameObject.Find("zombie(Clone)").GetComponent<Zombie>().health -= damage;
            Destroy(gameObject); //This destroys the gameobject the bullet script is attached to.
        }

    }
}

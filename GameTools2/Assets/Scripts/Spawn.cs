using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject SpawnItem;
    public Transform SpawnPos,SpawnPos1,SpawnPos2;

    private float loop = 1;


	void Start ()
    {
        StartCoroutine(SpawnDelay());
    }
	
	
	void Update ()
    {
        //StartCoroutine(SpawnDelay());
       
    }

    IEnumerator SpawnDelay()
    {
        while (loop > 0)
        {
            Instantiate(SpawnItem, SpawnPos);
            yield return new WaitForSeconds(10);
            Instantiate(SpawnItem, SpawnPos1);
            yield return new WaitForSeconds(10);
            Instantiate(SpawnItem, SpawnPos2);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject SpawnItem;//This is for the enemy gameobject.
    public Transform SpawnPos,SpawnPos1,SpawnPos2;//These 3 position are where the zombies will spawn.

    private float loop = 1;//This si for the while loop so it loops forever.

	void Start ()
    {
        StartCoroutine(SpawnDelay());//Starting the spawn coroutine.
    }
	
    IEnumerator SpawnDelay()
    {
        while (loop > 0)
        {
            Instantiate(SpawnItem, SpawnPos);//Spawns the zombie at SpawnPos.
            yield return new WaitForSeconds(10);//Game waits 10 seconds then spawns another zombie.
            Instantiate(SpawnItem, SpawnPos1);
            yield return new WaitForSeconds(10);
            Instantiate(SpawnItem, SpawnPos2);
        }
    }


}

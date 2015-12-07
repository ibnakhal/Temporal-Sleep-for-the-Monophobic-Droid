using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    [SerializeField]
    private int spawnCount;
    [SerializeField]
    private float spawnTimeDelay;
    public int spawned;
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private GameObject Door;



	// Use this for initialization
	void Start () {
        Spawning();



	}
	
	// Update is called once per frame
	void Update () {
	}


    public void Spawning()
    {

        if (spawned < spawnCount)
        {
            spawned++;
            GameObject clone = Instantiate(orb, this.transform.position, this.transform.rotation) as GameObject;  
        }


    }


}

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public GameObject spawn;
    public Spawner spawned;


	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Pipe");
        spawned = spawn.GetComponent<Spawner>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Flock")
        {
            spawned.spawned--;
            spawned.Spawning();
            Destroy(Other.gameObject);
        }

    }
}

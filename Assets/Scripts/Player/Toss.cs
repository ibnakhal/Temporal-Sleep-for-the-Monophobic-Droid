using UnityEngine;
using System.Collections;

public class Toss : MonoBehaviour {

    [SerializeField]
    private Transform bSpawn;
    [SerializeField]
    private GameObject watch;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool cooledDown;
    [SerializeField]
    private float time;

	// Use this for initialization
	void Start () {
        cooledDown = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (cooledDown)
            {
                GameObject clone = Instantiate(watch, bSpawn.position, bSpawn.rotation) as GameObject;
                clone.GetComponent<Rigidbody>().AddForce(bSpawn.transform.forward * speed);
                cooledDown = false;
                StartCoroutine(Reload());
            }
        }


	}


    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(time);
        cooledDown = true;
    }
}

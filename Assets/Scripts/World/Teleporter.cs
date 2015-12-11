using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    private Transform exit;
    [SerializeField]
    private bool open;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    public void OnTriggerEnter(Collider Other)
    {
        if(open && Other.tag == "Player")
        {
            Other.transform.position = exit.position;
            Other.transform.rotation = exit.rotation;

            //Other.transform.Rotate(exit.forward);
        }
    }
}

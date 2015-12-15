using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    private Transform exit;
    [SerializeField]
    private bool open;
    [SerializeField]
    private AudioSource teleport;
    [SerializeField]
    private Vector3 rotation;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}




    public void OnTriggerEnter(Collider Other)
    {
        if(open && Other.tag == "Player")
        {
            Other.transform.position = exit.position;
            //Other.GetComponent<FirstPersonController>().enabled = false;
            Other.transform.rotation = exit.rotation;
            
            teleport.Play();
            //Other.transform.Rotate(exit.forward);
        }
       // Other.GetComponent<FirstPersonController>().enabled = true;
    }
}

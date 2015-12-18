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
    [SerializeField]
    private Renderer rend;
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private string target;

    // Use this for initialization
    void Start () {

        rend.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }




    public void OnTriggerEnter(Collider Other)
    {
        if(open && Other.tag == target)
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

using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    [SerializeField]
    private int levelToLoad;
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private Renderer rend;



	// Use this for initialization
	void Start () {

        rend.GetComponent<Renderer>();



	}
	
	// Update is called once per frame
	void Update () {

        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));


	}

    public void OnTriggerEnter (Collider Other)
    {
        if(Other.tag == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}

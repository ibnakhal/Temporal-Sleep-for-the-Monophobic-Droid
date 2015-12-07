using UnityEngine;
using System.Collections;

public class Stopwatch : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    private float time;
    [SerializeField]
    private GameObject boom;
    [SerializeField]
    private string tag;

	void Start () {

        StartCoroutine(Boom());

	}
	
	// Update is called once per frame
	void Update () {
	

	}

    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == tag)
        {
            GameObject clone = Instantiate(boom, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(transform.parent.gameObject);
      
        }
    }


    public IEnumerator Boom()
    {
        yield return new WaitForSeconds(time);
        GameObject clone = Instantiate(boom, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(transform.parent.gameObject);

    }
}

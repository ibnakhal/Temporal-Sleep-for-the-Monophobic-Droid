using UnityEngine;
using System.Collections;

public class TimeBubble : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    [SerializeField]
    private float expansionSize;
    [SerializeField]
    private float Lifespan;
    [SerializeField]
    private int size;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private float warpedTimeScale;


	// Use this for initialization
	void Start () {
        

        StartCoroutine(Bloom());
        StartCoroutine(Life());


    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.forward * Time.deltaTime * speed);
	}


    public IEnumerator Bloom()
    {
        
        
            for(int x = 0; x <= size; x++)
            {
                yield return new WaitForSeconds(time);
                this.transform.localScale += new Vector3(expansionSize, expansionSize, expansionSize);
                Debug.Log(x);
            }


    }
    public IEnumerator Life()
    {
        yield return new WaitForSeconds(Lifespan);
        for (int x = 0; x <= size; x++)
        {
            yield return new WaitForSeconds(time);
            this.transform.localScale += new Vector3(-expansionSize, -expansionSize, -expansionSize);
            Debug.Log(x);
        }
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyTag)
        {
            other.GetComponent<EnemyAI>().SlowDown();
        }
    }

    public void OnTriggerExit(Collider Other)
    {
        if(Other.tag == enemyTag)
        {
            Other.GetComponent<EnemyAI>().SpeedUp();
        }
    }


}

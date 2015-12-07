using UnityEngine;
using System.Collections;

public class CaptureTrigger : MonoBehaviour {

    [SerializeField]
    static int caps;
    [SerializeField]
    private GameObject Field;
    [SerializeField]
    private GameObject Collider;
    [SerializeField]
    private GameObject Alignment;
    [SerializeField]
    private float timer;

    private int limiter;
    [SerializeField]
    public int totalCap;

    private GameObject ToCap;

    [SerializeField]
    private Spawner spawny;

    private bool bailout;
    private bool triggered;



	// Use this for initialization
	void Start () {

        spawny = GameObject.FindGameObjectWithTag("Pipe").GetComponent<Spawner>();

        triggered = false;
	}
	
	// Update is called once per frame
	void Update () {

        totalCap = caps;


	}


    public void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Flock")
        {
            limiter++;
            StartCoroutine(CountDown());
            ToCap = Other.gameObject;
        }
        if (Other.tag == "Player")
        {
            bailout = true;
        }
    }
    public void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "Flock")
        {
            limiter--;
        }
        if(Other.tag == "Player")
        {
            bailout = false;
        }
    }




    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(timer);
        if(limiter >= 1  && !bailout && !triggered)
        {
            ToCap.transform.position = Alignment.transform.position;
            ToCap.GetComponent<EnemyAI>().active = false;
            Debug.Log("LimitCount = " +limiter);

            Field.SetActive(true);
            Collider.SetActive(true);
            caps++;
            spawny.Spawning();
            triggered = true;
        }
    }

}

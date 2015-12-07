using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float myTimeScale;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float freezeSpeed;
    private float lockedSpeed;
    private bool freezing;
    [SerializeField]
	private int Iterations;
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private float maxV = 5;
    [SerializeField]
    private bool lerping = false;

    public bool active;
    // Use this for initialization
   
    private Rigidbody rigB;


    void Start () {
        lockedSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        active = true;
        StartCoroutine(ZeroOut());
        rigB = this.gameObject.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (active && !freezing)
        {
            if (!lerping)
            {
                this.transform.LookAt(Player);
            }
            if (lerping)
            {
                SmoothLook(Player.transform.position - this.transform.position);
            }
            rigB.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
        }


	}

    void SmoothLook(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
    }

    public IEnumerator ZeroOut()
    {
        while (active)
        {
            yield return new WaitForSeconds(1);
            if (rigB.velocity.x > maxV)
            {
                rigB.velocity = new Vector3(maxV, rigB.velocity.y, rigB.velocity.z);
            }
            if (rigB.velocity.y > maxV)
            {
                rigB.velocity = new Vector3(rigB.velocity.x, maxV, rigB.velocity.z);
            }
            if (rigB.velocity.z > maxV)
            {
                rigB.velocity = new Vector3(rigB.velocity.x, rigB.velocity.y, maxV);
            }
        }
    }

    public void SlowDown()
    {
        //slow down the movement variables
        freezing = true;
        StartCoroutine(Freeze());

    }

    public IEnumerator Freeze()
    {
        while (freezing)
        {
            rigB.velocity *= 0.8f;
            yield return new WaitForSeconds(freezeSpeed);

            if (rigB.velocity.x < 0.01)
            {
                rigB.velocity = new Vector3(0, rigB.velocity.y, rigB.velocity.z);
            }
            if (rigB.velocity.y < 0.01)
            {
                rigB.velocity = new Vector3(rigB.velocity.x, 0, rigB.velocity.z);
            }
            if (rigB.velocity.z < 0.01)
            {
                rigB.velocity = new Vector3(rigB.velocity.x, rigB.velocity.y, 0);
            }
        }

    }


    public void SpeedUp()
    {
        freezing = false;
        StartCoroutine(WakeUp());
        speed = lockedSpeed;
    }


    public IEnumerator WakeUp()
    {
        lerping = true;
        int number = 300;
        for (int x = 0; x < number; x++)
        {
            yield return new WaitForSeconds(0.001f);
        }
        lerping = false;
    }

}

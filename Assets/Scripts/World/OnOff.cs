using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {

    public float timeFrame;
    public GameObject[] toBlink;



	// Use this for initialization
	void Start () {
        StartCoroutine(Interval());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public IEnumerator Interval()
    {
        while(true)
        {
            Debug.Log("We Are Working Master!");
            for (int x = 0; x < toBlink.Length; x++)
            {
                Debug.Log("In the Loop!");
                toBlink[x].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(timeFrame);
            for(int x = 0; x < toBlink.Length;x++)
            {
                toBlink[x].gameObject.SetActive(false);

            }
            yield return new WaitForSeconds(timeFrame);

        }
    }



}

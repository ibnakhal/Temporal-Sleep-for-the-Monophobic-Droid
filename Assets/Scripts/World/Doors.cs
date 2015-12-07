using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

    [SerializeField]
    private int requiredNumber;
    [SerializeField]
    private GameObject anyCatchTriggerWillDo;
    public CaptureTrigger catcher;

	// Use this for initialization
	void Start () {

        catcher = anyCatchTriggerWillDo.gameObject.GetComponent<CaptureTrigger>();

	}
	
	// Update is called once per frame
	void Update () {

        if(catcher.totalCap == requiredNumber)
        {
            this.gameObject.SetActive(false);
        }

	
	}
}

using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    public bool locker=true;
	// Use this for initialization
	void Start () {


        Screen.lockCursor = locker;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

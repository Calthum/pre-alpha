using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        
        gameObject.GetComponent<Rigidbody>().AddForce(2, 6, 0, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

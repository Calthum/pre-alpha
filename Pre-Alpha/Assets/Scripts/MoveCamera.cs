using UnityEngine;
using System.Collections;


public class MoveCamera : MonoBehaviour {

    GameObject Camera;
    int scrollSpeed;
	// Use this for initialization
	void Start () {
        Camera = GameObject.Find("Main Camera");
        scrollSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            Camera.transform.Translate(0, scrollSpeed, 0);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            Camera.transform.Translate(-scrollSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Camera.transform.Translate(scrollSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Camera.transform.Translate(0, -scrollSpeed, 0);
        }
    }
}

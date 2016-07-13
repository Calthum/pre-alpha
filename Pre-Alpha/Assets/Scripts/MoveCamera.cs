using UnityEngine;
using System.Collections;


public class MoveCamera : MonoBehaviour
{

    GameObject Camera;
    float scrollSpeed;
    float angle;

    // Use this for initialization
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        scrollSpeed = 0.09f;
        angle = Mathf.PI / 8;
        Camera.transform.eulerAngles = new Vector3(90 - angle * 180 / Mathf.PI, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Camera.transform.Translate(0, scrollSpeed * Mathf.Cos(angle), scrollSpeed * Mathf.Sin(angle));
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
            Camera.transform.Translate(0, -scrollSpeed * Mathf.Cos(angle), -scrollSpeed * Mathf.Sin(angle));
        }

        if (Input.GetKey(KeyCode.O))
        {
            angle += Mathf.PI / 128;
            Camera.transform.eulerAngles = new Vector3(90 - angle * 180 / Mathf.PI, 0, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            angle -= Mathf.PI / 128;
            Camera.transform.eulerAngles = new Vector3(90 - angle * 180 / Mathf.PI, 0, 0);
        }
    }
}

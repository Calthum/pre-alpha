using UnityEngine;
using System.Collections;

public class GameClass : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Manager.Instance.GetNextInt(), 0);
        }
    }
}
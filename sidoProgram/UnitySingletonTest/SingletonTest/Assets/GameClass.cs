﻿using UnityEngine;
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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, ManagerDummy.Instance.GetNextInt(), 0);
            Quaternion.EulerAngles(1,1,1);
            
            
        }
    }
}
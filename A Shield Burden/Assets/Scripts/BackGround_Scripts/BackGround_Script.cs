using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Script : MonoBehaviour
{
    [SerializeField] float cloudSpeed = 10f;
    [SerializeField] GameObject clouds;

    void Update()
    {
        MoveClouds();
    }

    void MoveClouds()
    {
        clouds.transform.position += new Vector3(cloudSpeed, 0, 0) * Time.deltaTime;
    }
}

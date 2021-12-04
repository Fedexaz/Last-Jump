using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform objetivo;

    void Update()
    {
        transform.position = new Vector3(objetivo.transform.position.x, 10f, objetivo.transform.position.z - 5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioLugarCamara : MonoBehaviour
{
    public Transform objetivo;

    public Transform camPos_1;
    public Transform camPos_2;
    public Transform camPos_3;
    public Transform camPos_4;
    public Transform camPos_5;

    void Start()
    {
        objetivo = gameObject.transform;
    }

    void Update()
    {
        //Camara mirando al jugador siempre
        Camera.main.transform.LookAt(objetivo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Zona_1")
        {
            Camera.main.transform.position = camPos_1.position;
        }
        
        if (other.gameObject.tag == "Zona_2")
        {
            Camera.main.transform.position = camPos_2.position;
        }

        if (other.gameObject.tag == "Zona_3")
        {
            Camera.main.transform.position = camPos_3.position;
        }

        if (other.gameObject.tag == "Zona_4")
        {
            Camera.main.transform.position = camPos_4.position;
        }

        if (other.gameObject.tag == "Zona_5")
        {
            Camera.main.transform.position = camPos_5.position;
        }
    }
}

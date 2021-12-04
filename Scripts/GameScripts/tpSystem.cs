using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpSystem : MonoBehaviour
{
    public Transform teleportZone;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SALIDA AL FRENTE
            if (PlayerPrefs.GetInt("Llave_frente_casa") >= 1 && gameObject.name == "TPCasa-Frente")
            {
                Player.transform.position = teleportZone.position;
            }

            //ENTRADA A LA CASA (FRENTE)
            if (PlayerPrefs.GetInt("Llave_frente_casa") >= 1 && gameObject.name == "TPFrente-Casa")
            {
                Player.transform.position = teleportZone.position;
            }

            //SALIDA AL PATIO
            if (PlayerPrefs.GetInt("Llave_patio_casa") >= 1 && gameObject.name == "TPCasa-Patio")
            {
                Player.transform.position = teleportZone.position;
            }

            //ENTRADA A LA CASA (PATIO)
            if (PlayerPrefs.GetInt("Llave_patio_casa") >= 1 && gameObject.name == "TPPatio-Casa")
            {
                Player.transform.position = teleportZone.position;
            }
        }
    }
}
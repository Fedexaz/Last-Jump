using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //Flechas de las puertas

    //Puerta Frente Casa
    public GameObject flechaFrenteCasaVerde;
    public GameObject flechaFrenteCasaRoja;

    //Puerta Patio Casa
    public GameObject flechaPatioCasaVerde;
    public GameObject flechaPatioCasaRoja;

    void Update()
    {
        //Indicador de que la puerta del patio de la casa está abiertas
        if(PlayerPrefs.GetInt("Llave_patio_casa") >= 1)
        {
            flechaPatioCasaVerde.SetActive(true);
            flechaPatioCasaRoja.SetActive(false);
        }
        else
        {
            flechaPatioCasaVerde.SetActive(false);
            flechaPatioCasaRoja.SetActive(true);
        }

        //Indicador de que la puerta del frente de la casa esta abierta
        if (PlayerPrefs.GetInt("Llave_frente_casa") >= 1)
        {
            flechaFrenteCasaVerde.SetActive(true);
            flechaFrenteCasaRoja.SetActive(false);
        }
        else
        {
            flechaFrenteCasaVerde.SetActive(false);
            flechaFrenteCasaRoja.SetActive(true);
        }
    }

}

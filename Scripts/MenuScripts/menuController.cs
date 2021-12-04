using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject botonContinuar;
    public GameObject dialogIniciarNuevaPartida;

    public AudioSource Sonido;
    public AudioClip sonidoClick;

    private void Start()
    {
        if (PlayerPrefs.GetInt("PartidaIniciada") >= 1)
        {
            botonContinuar.GetComponent<Button>().interactable = true;
        }
    }

    public void SonidoClickBoton()
    {
        Sonido.PlayOneShot(sonidoClick);
    }

    public void IniciarPartida()
    {
        PlayerPrefs.SetInt("ReiniciarPartida", 1);
        SceneManager.LoadScene("Mapa");
    }

    public void ContinuarPartida()
    {
        if (PlayerPrefs.GetInt("PartidaIniciada") >= 1)
        {
            SceneManager.LoadScene("Mapa");
        }
    }

    public void ComprobarPartidaExistente()
    {
        if (PlayerPrefs.GetInt("PartidaIniciada") >= 1)
        {
            dialogIniciarNuevaPartida.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("NuevaPartida", 1);
            SceneManager.LoadScene("Mapa");
        }
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}

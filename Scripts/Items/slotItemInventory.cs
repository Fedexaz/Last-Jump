using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotItemInventory : MonoBehaviour
{
    public sistemaInventario sistemaInventario;
    public itemManager itemManager;

    private int opcionElegida;

    public void BotonUsar()
    {
        
        opcionElegida = sistemaInventario.SlotElegido;
        
        Debug.Log("Boton usar presionado (Slot " + opcionElegida + ")");

        if (PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) > 0 && itemManager.itemClave[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)] && !itemManager.itemDescartable[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)])
        {
            Debug.Log("Item Usado (Item " + PlayerPrefs.GetInt("SlotInv_" + opcionElegida) + ")");
            itemManager.UsarItem(PlayerPrefs.GetInt("SlotInv_" + opcionElegida), opcionElegida);
            sistemaInventario.MostrarInventario();
        }
        
        if (PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) > 0 && itemManager.itemDescartable[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)])
        {
            if (PlayerPrefs.GetInt("SlotInv_" + opcionElegida) != 1 && PlayerPrefs.GetInt("SlotInv_" + opcionElegida) != 7)
            {
                if (PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) == 1)
                {
                    Debug.Log("Item Usado (Item " + PlayerPrefs.GetInt("SlotInv_" + opcionElegida) + ")");
                    itemManager.UsarItem(PlayerPrefs.GetInt("SlotInv_" + opcionElegida), opcionElegida);
                    PlayerPrefs.SetInt("SlotInv_" + opcionElegida, 0);
                    PlayerPrefs.SetInt("CantSlotInv_" + opcionElegida, 0);
                    sistemaInventario.MostrarInventario();
                }

                if (PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) > 1)
                {
                    Debug.Log("Item Usado (Item " + PlayerPrefs.GetInt("SlotInv_" + opcionElegida) + ")");
                    itemManager.UsarItem(PlayerPrefs.GetInt("SlotInv_" + opcionElegida), opcionElegida);
                    PlayerPrefs.SetInt("CantSlotInv_" + opcionElegida, PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) - 1);
                    sistemaInventario.MostrarInventario();
                }
            }
            else
            {
                itemManager.UsarItem(PlayerPrefs.GetInt("SlotInv_" + opcionElegida), opcionElegida);
                sistemaInventario.MostrarInventario();
            }

         }
    }

    public void BotonTirar()
    {
        Debug.Log("Boton Tirar presionado");
        opcionElegida = sistemaInventario.SlotElegido;

        if(PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) > 1 && itemManager.itemDescartable[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)])
        {
            if(!itemManager.itemClave[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)])
            {
                PlayerPrefs.SetInt("CantSlotInv_" + opcionElegida, PlayerPrefs.GetInt("CantSlotInv_" + opcionElegida) - 1);
                GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
                alerta.GetComponent<Text>().text = "Objeto descartado correctamente.";
                Invoke("DeleteAlert", 1f);
            }
            else
            {
                GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
                alerta.GetComponent<Text>().text = "No puedes eliminar objetos clave";
                Invoke("DeleteAlert", 1f);
            }
        }
        else
        {
            if (!itemManager.itemClave[PlayerPrefs.GetInt("SlotInv_" + opcionElegida)])
            {
                PlayerPrefs.SetInt("SlotInv_" + opcionElegida, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + opcionElegida, 0);
                GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
                alerta.GetComponent<Text>().text = "Objeto descartado correctamente.";

                GameObject BotonUsar = GameObject.FindWithTag("BotonUsar");
                BotonUsar.GetComponent<Button>().interactable = false;

                GameObject BotonTirar = GameObject.FindWithTag("BotonTirar");
                BotonTirar.GetComponent<Button>().interactable = false;

                Invoke("DeleteAlert", 1f);
            }
            else
            {
                GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
                alerta.GetComponent<Text>().text = "No puedes eliminar objetos clave";
                Invoke("DeleteAlert", 1f);
            }
        }

        sistemaInventario.MostrarInventario();
        sistemaInventario.MostrarSlotInventario(opcionElegida);
    }

    void DeleteAlert()
    {
        GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
        alerta.GetComponent<Text>().text = " ";
    }
}
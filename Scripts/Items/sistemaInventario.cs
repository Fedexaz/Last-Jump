using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sistemaInventario : MonoBehaviour
{
    //
    //
    //  VARIABLES PARA EL INVENTARIO
    //
    //

    public int SlotElegido = 0;

    //LLAMAMOS AL ADMINISTRADOR DE ITEMS
    
    public itemManager itemManager;

    public Sprite[] ItemImage;

    public Sprite NoItemImage;

    //

    const int sizeInventario = 15; // TAMAÑO INVENTARIO (Por el momento no cambia)

    public void MostrarInventario()
    {
        int contador = 0;

        GameObject cantItemsInventarioText = GameObject.FindWithTag("ContadorItemsInventario");

        GameObject.FindGameObjectWithTag("BotonUsar").GetComponent<Button>().interactable = false;
        GameObject.FindGameObjectWithTag("BotonTirar").GetComponent<Button>().interactable = false;

        for (int i = 0; i < sizeInventario; i++)
        {
            if (PlayerPrefs.GetInt("SlotInv_" + i) != 0)
            {
                //Debug.Log(PlayerPrefs.GetInt("SlotInv_" + i));
                GameObject slot = GameObject.FindWithTag("Item_Inventario_" + i);
                slot.GetComponentInChildren<Text>().text = " ";
                slot.GetComponent<Button>().interactable = true;

                Image imagenItem = GameObject.FindGameObjectWithTag("Item_Inventario_" + i).GetComponent<Image>();
                imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_" + i)];

                //Contador de items

                contador += PlayerPrefs.GetInt("CantSlotInv_" + i);
            }
            else
            {
                GameObject slot = GameObject.FindWithTag("Item_Inventario_" + i);
                slot.GetComponentInChildren<Text>().text = " ";
                slot.GetComponent<Button>().interactable = false;

                GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
                nombreItem.GetComponent<Text>().text = "Nada";

                Image imagenItem = GameObject.FindGameObjectWithTag("Item_Inventario_" + i).GetComponent<Image>();
                imagenItem.sprite = NoItemImage;

                GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
                descItem.GetComponent<Text>().text = "Nada por aquí";
            }
        }

        cantItemsInventarioText.GetComponent<Text>().text = "Tienes " + contador + " objetos";
    }

    public void MostrarSlotInventario(int slot)
    {
        if (slot == 0)
        {
            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_0")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_0")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: "+ PlayerPrefs.GetInt("CantSlotInv_0") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_0")];
            SlotElegido = 0;
        }

        if (slot == 1)
        {
            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_1")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_1")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_1") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_1")];
            SlotElegido = 1;
        }

        if (slot == 2)
        {
            SlotElegido = 2;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_2")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_2")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_2") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_2")];
        }

        if (slot == 3)
        {
            SlotElegido = 3;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_3")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_3")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_3") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_3")];
        }

        if (slot == 4)
        {
            SlotElegido = 4;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_4")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_4")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_4") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_4")];
        }

        if (slot == 5)
        {
            SlotElegido = 5;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_5")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_5")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_5") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_5")];
        }

        if (slot == 6)
        {
            SlotElegido = 6;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_6")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_6")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_6") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_6")];
        }

        if (slot == 7)
        {
            SlotElegido = 7;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_7")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_7")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_7") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_7")];
        }

        if (slot == 8)
        {
            SlotElegido = 8;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_8")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_8")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_8") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_8")];
        }

        if (slot == 9)
        {
            SlotElegido = 9;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_9")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_9")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_9") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_9")];
        }

        if (slot == 10)
        {
            SlotElegido = 10;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_10")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_10")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_10") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_10")];
        }

        if (slot == 11)
        {
            SlotElegido = 11;
            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_11")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_11")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_11") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_11")];
        }

        if (slot == 12)
        {
            SlotElegido = 12;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_12")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_12")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_12") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_12")];
        }

        if (slot == 13)
        {
            SlotElegido = 13;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_13")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_13")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_13") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_13")];
        }

        if (slot == 14)
        {
            SlotElegido = 14;

            GameObject nombreItem = GameObject.FindWithTag("TituloObjetoInv");
            nombreItem.GetComponent<Text>().text = itemManager.nombreItem[PlayerPrefs.GetInt("SlotInv_14")];

            Image imagenItem = GameObject.FindGameObjectWithTag("ImagenObjetoInv").GetComponent<Image>();
            imagenItem.sprite = ItemImage[PlayerPrefs.GetInt("SlotInv_14")];

            GameObject descItem = GameObject.FindWithTag("DescripcionObjetoInv");
            descItem.GetComponent<Text>().text = "Cantidad: " + PlayerPrefs.GetInt("CantSlotInv_14") + "\n\n" + itemManager.descItem[PlayerPrefs.GetInt("SlotInv_14")];
        }
    }


    public void Start()
    {
        if(PlayerPrefs.GetInt("ReiniciarPartida") == 1 || PlayerPrefs.GetInt("NuevaPartida") == 1)
        {
            Debug.Log("Setear variables");
            PlayerPrefs.SetInt("ReiniciarPartida", 0);
            PlayerPrefs.SetInt("PartidaIniciada", 1);
            PlayerPrefs.SetInt("NuevaPartida", 0);

            PlayerPrefs.SetInt("SlotInv_0", 0);
            PlayerPrefs.SetInt("SlotInv_1", 0);
            PlayerPrefs.SetInt("SlotInv_2", 0);
            PlayerPrefs.SetInt("SlotInv_3", 0);
            PlayerPrefs.SetInt("SlotInv_4", 0);
            PlayerPrefs.SetInt("SlotInv_5", 0);
            PlayerPrefs.SetInt("SlotInv_6", 0);
            PlayerPrefs.SetInt("SlotInv_7", 0);
            PlayerPrefs.SetInt("SlotInv_8", 0);
            PlayerPrefs.SetInt("SlotInv_9", 0);
            PlayerPrefs.SetInt("SlotInv_10", 0);
            PlayerPrefs.SetInt("SlotInv_11", 0);
            PlayerPrefs.SetInt("SlotInv_12", 0);
            PlayerPrefs.SetInt("SlotInv_13", 0);
            PlayerPrefs.SetInt("SlotInv_14", 0);

            PlayerPrefs.SetInt("CantSlotInv_0", 0);
            PlayerPrefs.SetInt("CantSlotInv_1", 0);
            PlayerPrefs.SetInt("CantSlotInv_2", 0);
            PlayerPrefs.SetInt("CantSlotInv_3", 0);
            PlayerPrefs.SetInt("CantSlotInv_4", 0);
            PlayerPrefs.SetInt("CantSlotInv_5", 0);
            PlayerPrefs.SetInt("CantSlotInv_6", 0);
            PlayerPrefs.SetInt("CantSlotInv_7", 0);
            PlayerPrefs.SetInt("CantSlotInv_8", 0);
            PlayerPrefs.SetInt("CantSlotInv_9", 0);
            PlayerPrefs.SetInt("CantSlotInv_10", 0);
            PlayerPrefs.SetInt("CantSlotInv_11", 0);
            PlayerPrefs.SetInt("CantSlotInv_12", 0);
            PlayerPrefs.SetInt("CantSlotInv_13", 0);
            PlayerPrefs.SetInt("CantSlotInv_14", 0);

            //Variables de estado de la partida

            PlayerPrefs.SetInt("Llave_patio_casa", 0);
            PlayerPrefs.SetInt("Llave_frente_casa", 0);
            PlayerPrefs.SetInt("Llave_baul_auto", 0);
            PlayerPrefs.SetInt("Llave_deposito", 0);
            PlayerPrefs.SetInt("Llave_farmacia", 0);
            PlayerPrefs.SetInt("Llave_jugueteria", 0);
            PlayerPrefs.SetInt("Llave_reja_1", 0);
            PlayerPrefs.SetInt("Llave_reja_2", 0);
            PlayerPrefs.SetInt("Llave_reja_3", 0);
            PlayerPrefs.SetInt("Llave_tienda_desconocida", 0);
            PlayerPrefs.SetInt("Llave_generador", 0);
            PlayerPrefs.SetInt("Monedas", 0);
            PlayerPrefs.SetInt("Tarjeta_acceso", 0);

            PlayerPrefs.SetInt("SpawnItem_1", 0);
            PlayerPrefs.SetInt("SpawnItem_2", 0);
            PlayerPrefs.SetInt("SpawnItem_3", 0);
            PlayerPrefs.SetInt("SpawnItem_4", 0);
            PlayerPrefs.SetInt("SpawnItem_5", 0);
            PlayerPrefs.SetInt("SpawnItem_6", 0);
            PlayerPrefs.SetInt("SpawnItem_7", 0);
            PlayerPrefs.SetInt("SpawnItem_8", 0);
            PlayerPrefs.SetInt("SpawnItem_9", 0);

            PlayerPrefs.SetInt("SpawnItem_10", 0);
            PlayerPrefs.SetInt("SpawnItem_11", 0);
            PlayerPrefs.SetInt("SpawnItem_12", 0);
            PlayerPrefs.SetInt("SpawnItem_13", 0);
            PlayerPrefs.SetInt("SpawnItem_14", 0);
            PlayerPrefs.SetInt("SpawnItem_15", 0);
            PlayerPrefs.SetInt("SpawnItem_16", 0);
            PlayerPrefs.SetInt("SpawnItem_17", 0);
            PlayerPrefs.SetInt("SpawnItem_18", 0);
            PlayerPrefs.SetInt("SpawnItem_19", 0);

            PlayerPrefs.SetInt("SpawnItem_20", 0);
            PlayerPrefs.SetInt("SpawnItem_21", 0);
            PlayerPrefs.SetInt("SpawnItem_22", 0);
            PlayerPrefs.SetInt("SpawnItem_23", 0);
            PlayerPrefs.SetInt("SpawnItem_24", 0);
            PlayerPrefs.SetInt("SpawnItem_25", 0);
            PlayerPrefs.SetInt("SpawnItem_26", 0);
            PlayerPrefs.SetInt("SpawnItem_27", 0);
            PlayerPrefs.SetInt("SpawnItem_28", 0);
            PlayerPrefs.SetInt("SpawnItem_29", 0);
            PlayerPrefs.SetInt("SpawnItem_30", 0);
        }
    }
}
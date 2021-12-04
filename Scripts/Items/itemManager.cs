using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{

    //      LISTADO ITEMS
    //
    //  (0)- Sin item
    //  1-Llave Patio Casa
    //  2-Encendedor
    //  3-Lapiz
    //  4-Piedra
    //  5-Galletas
    //  6-Agua
    //  7-Llave Frente Casa
    //  8-Gaseosa Meneos
    //  9-Llave Baúl Auto
    //  10-Llave Caja Misteriosa
    //  11-Llave Depósito
    //  12-Llave Farmacia
    //  13-Llave Juguetería
    //  14-Llave Reja
    //  15-Llave Reja
    //  16-Llave Reja
    //  17-Llave Tienda Desconocida
    //  18-Llave Generador
    //  19-Monedas
    //  20-Tarjeta de Acceso
    //  21-Caja Misteriosa

    //
    //
    // ITEMS ARRAYS
    //
    //

    public string[] nombreItem;

    public string[] descItem;

    public bool[] itemClave;

    public bool[] itemDescartable;

    public string[] nombreNota;
    public string[] descNota;

    //
    //ITEMS MAPA FINAL
    //

    private void Start()
    {
        nombreItem = new string[]
        {
            " ",//0
            "Llave del Patio (Casa)",//1
            "Encendedor",//2
            "Lapiz",//3
            "Piedra",//4
            "Galletas",//5
            "Agua",//6
            "Llave del Frente (Casa)",//7
            "Gaseosa Meneos",//8
            "Llave baúl auto",//9
            "Llave caja misteriosa",//10
            "Llave del depósito",//11
            "Llave de la Farmacia",//12
            "Llave de la Juguetería",//13
            "Llave reja 1",//14
            "Llave reja 2",//15
            "Llave reja 3",//16
            "Llave tienda desconocida",//17
            "Llave generador",//18
            "Monedas",//19
            "Tarjeta de acceso",//20
            "Caja misteriosa"//21
        };

        descItem = new string[]
        {
            " ",
            "Con esta llave puedo abrir la puerta del patio de la casa.",
            "Algo puedo encender con esto.",
            "Podría tomar notas con él",
            "¿Qué puedo hacer con ella?",
            "Me servirán para reponer energías",
            "Un poco de agua no viene mal",
            "Con esta llave puedo abrir la puerta del frente de la casa.",
            "Una bebida poco saludable.",
            "Las llaves para abrir el baúl de un auto.",
            "Llave para abrir una caja con un signo de pregunta en ella.",
            "Las llaves para abrir el depósito que hay calles arriba.",
            "La llave para abrir la 'Farmacia de Norma'.",
            "LLave para abrir la Juguetería del centro.",
            "Con esto puedo abrir una reja.",
            "Con esto puedo abrir una reja.",
            "Con esto puedo abrir una reja.",
            "Con estas llaves abriré la tienda que no logro ver que hay dentro.",
            "Con estas llaves puedo activar el generador de emergencia.",
            "¿Monedas? Podrían servirme más adelante.",
            "Una tarjeta de Acceso a nombre de 'Daniel Pereyra'.",
            "Necesito una llave para ver que hay dentro de ella."
        };

        itemClave = new bool[]
        {
            false,
            true,
            true,
            true,
            true,
            false,
            false,
            true,
            false,
            true,
            false,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            false,
            true,
            false
        };
 
        itemDescartable = new bool[]
        {
            true,//0
            true,//1
            false,//2
            false,//3
            true,//4
            true,//5
            true,//6
            true,//7
            false,//8
            true,//9
            true,//10
            true,//11
            true,//12
            true,//13
            true,//14
            true,//15
            true,//16
            true,//17
            true,//18
            false,//19
            true,//20
            false//21
        };
    }

    public void UsarItem(int item, int slot)
    {
        if(item == 1)//Llaves patio casa.
        {
            if (PlayerPrefs.GetInt("Llave_patio_casa") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("PuertaPatioCasa").gameObject.transform.position) <= 3)
            {
                Debug.Log("Usaste la llave");
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_patio_casa", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves del patio (Casa)";

                Invoke("DeleteAlert", 1f);

                print("Puerta abierta");
            }
            else
            {
                Debug.Log("No pudiste usar la llave");
                PlayerPrefs.SetInt("SlotInv_" + slot, 1);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "No puedo usarlas ahora";

                Invoke("DeleteAlert", 1f);

            }
        }

        if (item == 2)//Encendedor
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado el encendedor";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);

        }

        if (item == 3)//Lapiz
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado el lápiz";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);

        }

        if (item == 4)//Piedra
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado una piedra";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
        }

        if (item == 5)//Galletas
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado las galletas";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
        }

        if (item == 6)//Agua
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado el agua";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
        }

        if (item == 7)//Llaves frente casa.
        {
            if (PlayerPrefs.GetInt("Llave_frente_casa") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("PuertaFrenteCasa").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_frente_casa", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves del frente (Casa)";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 8)//Gaseosa Meneos
        {
            /*
            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Gaseosa Meneos";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
            */
        }

        if (item == 9)//Llave baúl auto.
        {
            if (PlayerPrefs.GetInt("Llave_baul_auto") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("BaulAuto").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_baul_auto", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves del baul (Auto)";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 11)//Llaves depósito.
        {
            if (PlayerPrefs.GetInt("Llave_deposito") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Deposito").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_deposito", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves del depósito";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 12)//Llaves farmacia.
        {
            if (PlayerPrefs.GetInt("Llave_farmacia") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Farmacia").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_farmacia", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la farmacia";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 13)//Llaves juguetería.
        {
            if (PlayerPrefs.GetInt("Llave_jugueteria") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Jugueteria").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_jugueteria", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la jugueteria";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 14)//Llaves reja 1.
        {
            if (PlayerPrefs.GetInt("Llave_reja_1") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Reja1").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_reja_1", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la Reja";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 15)//Llaves reja 2.
        {
            if (PlayerPrefs.GetInt("Llave_reja_2") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Reja2").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_reja_2", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la reja";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 16)//Llaves reja 3.
        {
            if (PlayerPrefs.GetInt("Llave_reja_3") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Reja3").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_reja_3", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la reja";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 17)//Llaves tienda desconocida.
        {
            if (PlayerPrefs.GetInt("Llave_tienda_desconocida") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("TiendaDesconocida").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_tienda_desconocida", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves de la tienda desconocida";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 18)//Llaves generador.
        {
            if (PlayerPrefs.GetInt("Llave_generador") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Generador").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Llave_generador", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las llaves del generador";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 19)//Monedas.
        {
            if (PlayerPrefs.GetInt("Monedas") >= 10 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Tragamonedas").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Monedas", 0);
                PlayerPrefs.SetInt("NuevaSkin", 1);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las monedas en la Máquina";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 20)//Tarjeta de acceso.
        {
            if (PlayerPrefs.GetInt("Tarjeta_acceso") == 0 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Caja_fuerte").gameObject.transform.position) <= 3)
            {
                PlayerPrefs.SetInt("SlotInv_" + slot, 0);
                PlayerPrefs.SetInt("CantSlotInv_" + slot, 0);

                PlayerPrefs.SetInt("Tarjeta_acceso", 0);

                gameObject.GetComponent<sistemaInventario>().MostrarInventario();

                GameObject alerta = GameObject.FindWithTag("AlertaInfo");

                alerta.GetComponent<Text>().text = "Has usado las tarjeta de acceso";

                Invoke("DeleteAlert", 1f);
            }
        }

        if (item == 21)//Caja Misteriosa
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado la caja misteriosa";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
        }

        if (item == 10)//LlaveCajaMisteriosa
        {

            GameObject alerta = GameObject.FindWithTag("AlertaInfo");
            alerta.GetComponent<Text>().text = "Has usado las llaves de la caja misteriosa";

            gameObject.GetComponent<sistemaInventario>().MostrarInventario();

            Invoke("DeleteAlert", 1f);
        }
    }

    void DeleteAlert()
    {
        GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
        alerta.GetComponent<Text>().text = " ";
    }

    public bool DarItem(int item, int cantidad)
    {
        bool seDioItem = false;

        /*
        GameObject alerta = GameObject.FindGameObjectWithTag("AlertaInfo");
        alerta.GetComponent<Text>().text = " ";
        */

        if (item != 0 && cantidad != 0)
        {
            bool asignarNuevoItem = false;

            for (int i = 0; i < 15; i++)
            {
                if (PlayerPrefs.GetInt("SlotInv_" + i) == item)
                {
                    PlayerPrefs.SetInt("CantSlotInv_" + i, PlayerPrefs.GetInt("CantSlotInv_" + i) + cantidad);
                    asignarNuevoItem = true;
                    seDioItem = true;
                    print("Item agregado a los actuales");
                    break;
                }
            }

            if (!asignarNuevoItem)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (PlayerPrefs.GetInt("SlotInv_" + i) == 0 && PlayerPrefs.GetInt("CantSlotInv_" + i) == 0)
                    {
                        PlayerPrefs.SetInt("SlotInv_" + i, item);
                        PlayerPrefs.SetInt("CantSlotInv_" + i, cantidad);
                        print("Nuevo item agregado");
                        seDioItem = true;
                        break;
                    }
                }
            }
        }
        else
        {
            print("El item o la cantidad no existen.");
        }

        return seDioItem;
    }

}

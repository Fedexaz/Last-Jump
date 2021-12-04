using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPickManager : MonoBehaviour
{
    public itemManager itemManager;

    public AudioSource AudioSource;
    public AudioClip AudioClip;

    public int ItemADar;
    public int CantidadDelItemADar;

    public int IDItem;

    private void Start()
    {
        if (PlayerPrefs.GetInt("SpawnItem_" + IDItem) > 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(itemManager.DarItem(ItemADar, CantidadDelItemADar))
            {
                AudioSource.PlayOneShot(AudioClip, 1f);
                PlayerPrefs.SetInt("SpawnItem_" + IDItem, 1);
                Invoke("DestroyItem", .25f);
            }
            else
            {

            }
        }
    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }
}

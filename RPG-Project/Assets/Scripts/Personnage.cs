using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personnage : MonoBehaviour
{
    public GameObject Perso1, Perso2;

    private bool ChangeClick = true;
    private GameObject m_testActive;
    private void Start()
    {
        Perso1.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ChangerClick()
    {
        for (int i = 0; i < 3; i++)
        {
            Perso1.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = ChangeClick;
        }
        ChangeClick = !ChangeClick;
    }

    public void ChangerTour()
    {
        ChangerClick();

        if(ChangeClick == true) { }
        
    }

    public void AppliquerDommage()
    {

    }

    
}

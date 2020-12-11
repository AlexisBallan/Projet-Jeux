using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personnage : MonoBehaviour
{
    public GameObject Perso1, Perso2;
    public GameObject ButtonFinDeTour;

    private GameObject JoueurActif;
    private bool ChangeClick = false;
    private GameObject m_testActive;

    private void Start()
    {
        Perso1.transform.GetChild(0).gameObject.SetActive(true);

        JoueurActif = Perso1;
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

        if (JoueurActif == Perso1)
            JoueurActif = Perso2;
        else
            JoueurActif = Perso1;
    }
    public void FinDeTour()
    {
        if (JoueurActif == Perso1)
            ButtonFinDeTour.GetComponent<Button>().interactable = false;
        else
            ButtonFinDeTour.GetComponent<Button>().interactable = true;

        ChangerTour();

        if (JoueurActif == Perso1)
            Perso2.GetComponent<King>().IAMode();
        else
            Perso1.GetComponent<Warrior>().IAMode();
    }

    public void AppliquerDommage(int degat)
    {
        if (Perso1 == JoueurActif)
            Perso2.GetComponent<King>().TakeDamage(degat);
        else
            Perso1.GetComponent<Warrior>().TakeDamage(degat);


    }

    
}

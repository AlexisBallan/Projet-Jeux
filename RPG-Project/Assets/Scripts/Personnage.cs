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

        Perso1.GetComponent<Ennemi>().IsJoueurAcitf = true;

        Perso1.GetComponent<Ennemi>().SetStamina();
    }

    public void ChangerClick()
    {
        Perso1.GetComponent<Ennemi>().IsJoueurAcitf = ChangeClick;

        for (int i = 0; i < 3; i++)
        {
            Perso1.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = ChangeClick;
        }

        ChangeClick = !ChangeClick;
    }

    public void ChangerTour()
    {
        if (JoueurActif == Perso1)
            ButtonFinDeTour.GetComponent<Button>().interactable = false;
        else
            ButtonFinDeTour.GetComponent<Button>().interactable = true;
            

        ChangerClick();

        if (JoueurActif == Perso1)
        {
            JoueurActif = Perso2;
            Perso2.GetComponent<Ennemi>().SetStamina();
        }
        else
        {
            JoueurActif = Perso1;
            Perso1.GetComponent<Ennemi>().SetStamina();
        }
    }
    public void FinDeTour()
    {
        ChangerTour();
        Debug.Log("Changement de tour " + Random.Range(0, 750));

        Perso2.GetComponent<Ennemi>().IAMode();
    }

    public void AppliquerDommage(int degat)
    {
        if (Perso1 == JoueurActif)
            Perso2.GetComponent<Ennemi>().TakeDamage(degat);
        else
            Perso1.GetComponent<Ennemi>().TakeDamage(degat);
    }

    public void AppliquerStunt(int a_Stunt)
    {
        if (Perso1 == JoueurActif)
            Perso2.GetComponent<Ennemi>().TakeStunt(a_Stunt);
        else
            Perso1.GetComponent<Ennemi>().TakeStunt(a_Stunt);
    }
}

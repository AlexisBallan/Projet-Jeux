using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public int VieRoi = 150;
    public int Resistance, minResistance = 5, maxResistance = 10;
    public int Degat, minDegat = 50, maxDegat = 60;
    public Animator anim;
    public int Stamina = 10;

    private Personnage Personnage;
    private bool IsDead = false;
    



    private void Awake()
    {
        Personnage = GameObject.Find("GererTout").GetComponent<Personnage>();
    }
    public void IAMode()
    {

    }


    public int GetResistance()
    {
        return Resistance = Random.Range(minResistance, maxResistance);
    }

    public int DoDegat()
    {
        return Degat = Random.Range(minDegat, maxDegat);
    }

    public void TakeDamage(int a_TakeDamage)
    {
        a_TakeDamage -= GetResistance();

        if (a_TakeDamage < 5)
            a_TakeDamage = 5;

        VieRoi -= a_TakeDamage;

        VerifMort();

        Debug.Log(VieRoi);
        Debug.Log(a_TakeDamage);
    }

    private void VerifMort()
    {
        if (VieRoi <= 0)
            IsDead = true;
    }

    public void Attaque()
    {
        Personnage.AppliquerDommage(DoDegat());

        int RandomAnim = Random.Range(0, 4);

        if (RandomAnim == 0)
            anim.SetTrigger("Attack1");
        else if (RandomAnim == 1)
            anim.SetTrigger("Attack2");
        else
            anim.SetTrigger("Attack3");
    }

    public void Assomement()
    {

    }

    public void Ulti()
    {

    }
}

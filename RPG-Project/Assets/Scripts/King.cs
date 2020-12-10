using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public float VieRoi = 150;
    public float Resistance, minResistance = 5, maxResistance = 10;
    public float Degat, minDegat = 50, maxDegat = 60;
    public Animator anim;

    private Personnage Personnage;
    private bool IsDead = false;
    



    private void Awake()
    {
        Personnage = GameObject.Find("GererTout").GetComponent<Personnage>();
    }
    public void IAMode()
    {

    }


    public float GetResistance()
    {
        return Resistance = Random.Range(minResistance, maxResistance);
    }

    public float DoDegat()
    {
        return Degat = Random.Range(minDegat, maxDegat);
    }

    public void TakeDamage(float a_TakeDamage)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float VieWarrior = 120;
    public float Resistance, minResistance = 13, maxResistance = 17;
    public float Degat, minDegat = 30, maxDegat = 40;
    public Animator anim;

    private Personnage Personnage;
    private bool IsDead = false;

    public void IAMode()
    {

    }

    private void Awake()
    {
        Personnage = GameObject.Find("GererTout").GetComponent<Personnage>();
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

        VieWarrior -= a_TakeDamage;

        VerifMort();

        Debug.Log(VieWarrior);
        Debug.Log(a_TakeDamage);
    }

    private void VerifMort()
    {
        if (VieWarrior <= 0)
            IsDead = true;
    }

    public void Attaque()
    {
        Personnage.AppliquerDommage(DoDegat());
        int RandomAnim = Random.Range(0, 3);

        if (RandomAnim == 0)
            anim.SetTrigger("Attack1");
        else
            anim.SetTrigger("Attack2");
    }

    public void Assomement()
    {

    }

    public void Ulti()
    {

    }
}

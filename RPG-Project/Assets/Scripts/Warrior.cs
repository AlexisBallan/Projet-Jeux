using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float VieWarrior = 120;
    public float Resistance, minResistance = 13, maxResistance = 17;
    public float Degat, minDegat = 30, maxDegat = 40;

    private bool IsDead = false;

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
        float t_TakeDamage = a_TakeDamage - GetResistance();

        if (t_TakeDamage < 5)
            t_TakeDamage = 5;

        VieWarrior -= t_TakeDamage;

        VerifMort();
    }

    private void VerifMort()
    {
        if (VieWarrior <= 0)
            IsDead = true;
    }

    public void Attaque()
    {

    }

    public void Assomement()
    {

    }

    public void Ulti()
    {

    }
}

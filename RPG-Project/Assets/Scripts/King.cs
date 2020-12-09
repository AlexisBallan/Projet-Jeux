using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public float VieRoi = 150;
    public float Resistance, minResistance = 5, maxResistance = 10;
    public float Degat, minDegat = 50, maxDegat = 60;

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

        VieRoi -= t_TakeDamage;

        VerifMort();
    }

    private void VerifMort()
    {
        if (VieRoi <= 0)
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

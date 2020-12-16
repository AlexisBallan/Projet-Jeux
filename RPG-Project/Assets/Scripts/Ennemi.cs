using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemi : MonoBehaviour
{
    public float Vie = 150;
    public int Stamina = 10;
    public int Resistance, minResistance = 13, maxResistance = 17;
    public int Degat, minDegat = 30, maxDegat = 40;
    public bool IsJoueurAcitf;
    public int CoutSpell1, CoutSpell2, CoutSpell3;
    public int Stunt;
    public int Heal;
    public Slider currentHealthBar;
    public float BaseLife;
    public Animator anim;

    private bool[] IsUseFull = new bool[4];
    private bool IsDead = false;

    protected Personnage Personnage;
    public bool WaitIsInAction;

    public virtual void TakeDamage(int a_TakeDamage)
    {
        a_TakeDamage -= GetResistance();

        if (a_TakeDamage < 5)
            a_TakeDamage = 5;

        Vie -= a_TakeDamage;

        VerifMort();

        Stamina += (int)a_TakeDamage / 10;
    }

    public virtual void TakeStunt(int a_Stunt)
    {
        Stamina -= a_Stunt;
    }

    private void Awake()
    {
        Personnage = GameObject.Find("GererTout").GetComponent<Personnage>();
    }

    public void SetStamina()
    {
        Stamina += 10;
    }

    private void VerifMort()
    {
        if (Vie <= 0)
        {
            IsDead = true;
            anim.SetTrigger("Death");
            Time.timeScale = 0f;
        }
    }

    public int GetResistance()
    {
        return Resistance = Random.Range(minResistance, maxResistance);
    }

    public int DoDegat()
    {
        return Degat = Random.Range(minDegat, maxDegat);
    }

    public virtual void IAMode() { }

    private void FixedUpdate()
    {
        float Ratio = (Vie / BaseLife);
        currentHealthBar.GetComponent<Slider>().value = Ratio;
    }

    private void Update()
    {
        if (IsJoueurAcitf)
        {
            if (Stamina < CoutSpell1)
                IsUseFull[0] = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
            else
                IsUseFull[0] = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;

            if (Stamina < CoutSpell2)
                IsUseFull[1] = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
            else
                IsUseFull[1] = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = true;

            if (Stamina < CoutSpell3)
                IsUseFull[2] = transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            else
                IsUseFull[2] = transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public virtual void Spell1() { }

    public virtual void Spell2() { }

    public virtual void Spell3() { }

}

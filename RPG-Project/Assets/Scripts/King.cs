using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : Ennemi
{
    public GameObject AnimHeal;
    public GameObject AnimLumiere;

    private bool IsBotAttacking = true;
    private bool IA = false;

    public override void IAMode()
    {
        IA = true;
        StartCoroutine(WaitAnim());
    }

    public IEnumerator WaitAnim()
    {
        IsBotAttacking = true;

        yield return new WaitForSeconds(0.5f);
        IsBotAttacking = false;
    }

    private void FinTour()
    {
        Personnage.ChangerTour();
    }

    //Fonctionnement de l'IA 
    private void Update()
    {
        if (IsBotAttacking == false && IA == true)
        {
            if (Stamina >= 6)
            {
                if (Vie < 100)
                {
                    if (Stamina < 8)
                    {
                        int Action = Random.Range(0, 4);

                        if (Action == 3)
                        {
                            IA = false;
                            FinTour();
                        }
                        else
                            Spell3();
                    }
                    else if (Stamina < 22)
                    {
                        int Action = Random.Range(0, 11);

                        if (Action < 5)
                            Spell1();
                        else
                            Spell3();
                    }
                    else
                    {
                        int Action = Random.Range(0, 10);
                        
                        if (Action < 2)
                            Spell1();
                        else
                            Spell2();
                    }
                }
                else
                {
                    if (Stamina < 8)
                    {
                        int Action = Random.Range(0, 4);

                        if (Action == 3)
                        {
                            IA = false;
                            FinTour();
                        }
                        else
                            Spell3();
                    }
                    else
                    {
                        int Action = Random.Range(0, 22);

                        if (Action == 21)
                        {
                            IA = false;
                            FinTour();
                        }
                        else if (Action <= 10)
                            Spell1();
                        else
                            Spell3();
                    }
                }
            }
            else
            {
                IA = false;
                FinTour();
            }
        }
    }

    //Attaque normal
    public override void Spell1()
    {
        base.Spell1();
        StartCoroutine(WaitAnim());

        Personnage.AppliquerDommage(DoDegat());
        int RandomAnim = Random.Range(0, 3);

        if (RandomAnim == 0)
            anim.SetTrigger("Attack1");
        else
            anim.SetTrigger("Attack2");

        Stamina -= CoutSpell1;
    }

    //heal
    public override void Spell3()
    {
        base.Spell3();
        StartCoroutine(WaitAnim());

        Instantiate(AnimHeal, new Vector3(transform.position.x - 1, transform.position.y - 2, transform.position.z), Quaternion.identity);

        Vie = Vie + Heal;

        Stamina -= CoutSpell3;
    }

    //Lumiere
    public override void Spell2()
    {
        base.Spell2();
        StartCoroutine(WaitAnim());

        Instantiate(AnimLumiere, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Quaternion.identity);

        Vie = BaseLife;

        Stamina -= CoutSpell2;
    }
}

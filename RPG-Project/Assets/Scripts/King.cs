using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : Ennemi
{
    public Animator anim;

    public override void IAMode()
    {
        base.IAMode();

        while(Stamina > 8)
        {
            if (Vie < 100)
            {
                if (Stamina < 15)
                {
                    int Action = Random.Range(0, 3);

                    if (Action == 2)
                        return;
                    else
                        Spell1();
                }
                else if (Stamina < 25)
                {
                    int Action = Random.Range(0, 7);

                    if (Action == 5)
                        return;
                    else if (Action <= 1)
                        Spell1();
                    else
                        Spell3();
                }
                else
                {
                    int Action = Random.Range(0, 15);

                    if (Action == 14)
                        return;
                    else if (Action < 2)
                        Spell1();
                    else if (Action < 5)
                        Spell3();
                    else
                        Spell2();
                }
            }
            else
            {
                if (Stamina < 25)
                {
                    int Action = Random.Range(0, 3);

                    if (Action == 2)
                        Personnage.ChangerTour();
                    else 
                        Spell1();
                }
                else
                {
                    int Action = Random.Range(0, 8);

                    if (Action == 7)
                        return;
                    else if (Action < 2)
                        Spell1();
                    else
                        Spell2();
                }
            }
        }
    }

    //Attaque normal
    public override void Spell1()
    {
        base.Spell1();

        Personnage.AppliquerDommage(DoDegat());
        int RandomAnim = Random.Range(0, 3);

        if (RandomAnim == 0)
            anim.SetTrigger("Attack1");
        else
            anim.SetTrigger("Attack2");

        Stamina -= CoutSpell1;
    }

    //Lumiere
    public override void Spell2()
    {
        base.Spell2();

        //rajouter une animation

        Vie = Vie + Heal;

        Stamina -= CoutSpell2;
    }

    //Heal
    public override void Spell3()
    {
        base.Spell3();

        // rajouter une animation

        Vie = 150;

        Stamina -= CoutSpell3;
    }
}

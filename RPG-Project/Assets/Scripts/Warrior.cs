using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : Ennemi
{
    public Animator anim;

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

    //Assomement
    public override void Spell2()
    {
        base.Spell2();

        Personnage.AppliquerDommage(55);

        Personnage.AppliquerStunt(Stunt);

        Stamina -= CoutSpell2;
    }

    //Decoupage
    public override void Spell3()
    {
        base.Spell3();

        StartCoroutine(Decoupage());

        Stamina -= CoutSpell3;
    }

    private IEnumerator Decoupage()
    {
        for (int i = 0; i < 3; i++)
        {
            Personnage.AppliquerDommage(DoDegat());
            int RandomAnim = Random.Range(0, 3);

            if (RandomAnim == 0)
                anim.SetTrigger("Attack1");
            else
                anim.SetTrigger("Attack2");

            yield return new WaitForSeconds(0.5f);
        }
    }
}

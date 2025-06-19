using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName; // naam van de character
    public int unitLevel; // naam van de character

    public float damage; // hoeveel vaste damage dat die heeft

    public int maxHP; // Het hoogste aantal hit points dat die character can hebben
    public float currentHP; // Hoeveel hit points dat die momenteel heeft
    public int criticalChance; // De kans van een "critical hit" te doen
    public bool isCrit(int crit) // checken als het een critical hit is
    {
        int rand = Random.Range(0, 99);

        if (rand < crit)
            return true;
        else
            return false;

    }
    public bool TakeDamage(float dmg) 
    {

        //if (isCrit(crit))
        //{
        //    dmg = dmg * 1.50F; crit multiplier verplaatst naar battlesystem
        //}

        currentHP -= dmg;

        if  (currentHP <= 0)
            return true;
        else
            return false;
    }

}

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public float damage;

    public int maxHP;
    public float currentHP;
    public int criticalChance;
    public bool isCrit(int crit) 
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
        //    dmg = dmg * 1.50F;
        //}

        currentHP -= dmg;

        if  (currentHP <= 0)
            return true;
        else
            return false;
    }

}

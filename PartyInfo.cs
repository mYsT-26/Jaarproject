using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PartyInfo : MonoBehaviour
{
    public TMP_Text infoText;
    public TMP_Text hpIndicator;
    private float hp = 0;
    private int maxHp = 0;

    public void SetInfo(Unit unit)
    {
        infoText.text = $"{unit.unitName} Lvl {unit.unitLevel}";
        hp = unit.currentHP;
        maxHp = unit.maxHP;
        hpIndicator.text = $"HP {hp}/{maxHp}";
            
    }

    public void SetHP(float hp)
    {
        hpIndicator.text = $"HP {hp}/{maxHp}";
    }

}

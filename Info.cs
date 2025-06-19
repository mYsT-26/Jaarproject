using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    Unit playerUnit;
    public GameObject playerGO;
    public PartyInfo playerInfo;
    void Start()
    {
        
        playerUnit = playerGO.GetComponent<Unit>();
        playerInfo.SetInfo(playerUnit);
    }

}

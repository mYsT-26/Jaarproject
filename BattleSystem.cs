using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform Station1;
    public Transform enemeyStation1;

    Unit playerUnit;
    Unit enemyUnit;
    public string unitName;

    public TMP_Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    public float p1Damage;
    public float n1Damage;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, Station1);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemeyStation1);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " does nothing...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack() 
    {
        bool isCrit = playerUnit.isCrit(playerUnit.criticalChance);
        if (isCrit)
            p1Damage = playerUnit.damage * 1.50F;
        else
            p1Damage = playerUnit.damage;

        bool isDead = enemyUnit.TakeDamage(p1Damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        if (isCrit)
            dialogueText.text = $"A critical hit!";
        else
            dialogueText.text = $"{enemyUnit.unitName} took {playerUnit.damage} damage.";

        if(isDead) 
        {
            
            state = BattleState.WON;
            if (isCrit)
                dialogueText.text = $"A critical hit!";
            else
                dialogueText.text = $"{enemyUnit.unitName} took {playerUnit.damage} damage.";
            yield return new WaitForSeconds(2f);
            EndBattle();
        } else
        {
            
            state = BattleState.ENEMYTURN;
            if (isCrit)
                dialogueText.text = $"A critical hit!";
            else
                dialogueText.text = $"{enemyUnit.unitName} took {playerUnit.damage} damage.";
            yield return new WaitForSeconds(2f);
            StartCoroutine(EnemyTurn());
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator EnemyTurn() 
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isCrit = enemyUnit.isCrit(enemyUnit.criticalChance);
        if (isCrit)
            n1Damage = enemyUnit.damage * 1.50F;
        else
            n1Damage = enemyUnit.damage;

        bool isDead = playerUnit.TakeDamage(n1Damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead) 
        {
            state = BattleState.PLAYERTURN;
        }else 
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle() 
    {
        if(state == BattleState.WON) 
        {
            dialogueText.text = $"{playerUnit.unitName} was victorious!";
        }else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerAttack());
    }

}

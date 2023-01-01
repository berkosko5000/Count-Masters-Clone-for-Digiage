using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject ally;
    [SerializeField] GameObject playerParty;
    [SerializeField] TMP_Text allyCountText;
    [HideInInspector] public int allyCount;
    [HideInInspector] public int enemyCount;
    [SerializeField] TMP_Text enemyCountText;

    void Start()
    {
        InstantiateFirstAlly();
    }
    void InstantiateFirstAlly()
    {
        GameObject ally = ObjectPooler.SharedInstance.GetPooledObject("Ally");
        ally.transform.position = transform.position;
        ally.transform.SetParent(playerParty.transform);
        ally.GetComponent<PartyMember>().JoinTeam();
        ally.SetActive(true);
    }
    public void ChangeAllyCount(int amount)
    {
        allyCount += amount;
        if (allyCount < 0)
        {
            allyCount = 0;
            //Loseeeeee
        }
        allyCountText.text = allyCount.ToString();
    }
    public void ChangeEnemyCount(int amount)
    {
        enemyCount += amount;
        if (enemyCount < 0)
        {
            enemyCount = 0;
        }
        enemyCountText.text = enemyCount.ToString();
    }
}

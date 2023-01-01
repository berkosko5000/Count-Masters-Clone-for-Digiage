using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    void Update(){
        
        /*if (enemyCount == 0){
            Debug.Log("ally count = " + allyCount);
            Debug.Log(GameObject.FindGameObjectsWithTag("Ally").Length);
            for(int i = GameObject.FindGameObjectsWithTag("Ally").Length; i > allyCount; i--){
                Debug.Log("y");
                GameObject.FindGameObjectsWithTag("Ally")[i-1].GetComponent<PartyMember>().LeaveParty(); 
            }
        }*/
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        allyCountText.text = allyCount.ToString();
    }
    public void ChangeEnemyCount(int amount)
    {
        enemyCount += amount;
        if (enemyCount <= 0)
        {
            enemyCount = 0;
            playerParty.GetComponent<Swipe>().enabled = true;  
        }
        enemyCountText.text = enemyCount.ToString();
    }
}

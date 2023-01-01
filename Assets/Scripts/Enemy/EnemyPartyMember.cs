using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartyMember : MonoBehaviour
{
    [HideInInspector] public LevelManager levelManager;
    [SerializeField] GameObject pool;
    List<EnemyPoint> enemyPoints;

    private void Awake()
    {
        pool = GameObject.FindGameObjectWithTag("Pool");
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    public void JoinTeam()
    {
        GetComponent<Move>().StartMoveToDirection();
        GetComponent<MovementClass>().StartMovement();
        GetComponent<CapsuleCollider>().enabled = true;
        enemyPoints = transform.parent.GetComponent<EnemyPointSetter>().enemyPoints;
        foreach (EnemyPoint enemyPoint in enemyPoints)
        {
            if (!enemyPoint.EnemyObject)
            {
                enemyPoint.EnemyObject = gameObject;
                GetComponent<MoveToTarget>().target = enemyPoint.Point;
                levelManager.ChangeEnemyCount(1);
                break;
            }
        }
    }
     public void LeaveParty()
    {
        this.transform.SetParent(pool.transform);
        GetComponent<CapsuleCollider>().enabled = false;
        //GetComponent<Animator>().SetTrigger("Fall");
        GetComponent<Move>().StopMoveToDirection();
        GetComponent<MovementClass>().StopMovement();
        levelManager.ChangeEnemyCount(-1);

        foreach (EnemyPoint enemyPoint in enemyPoints)
        {
            if (enemyPoint.EnemyObject == gameObject)
            {
                enemyPoint.EnemyObject = null;
                break;
            }
        }

        gameObject.SetActive(false);
    }
}

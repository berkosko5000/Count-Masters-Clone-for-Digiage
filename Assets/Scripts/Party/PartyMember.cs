using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [HideInInspector] public LevelManager levelManager;
    [SerializeField] GameObject pool;
    List<AllyPoint> allyPoints;

    private void Awake(){
        pool = GameObject.FindGameObjectWithTag("Pool");
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }
    public void JoinTeam()
    {
        GetComponent<Move>().StartMoveToDirection();
        GetComponent<MovementClass>().StartMovement();
        GetComponent<CapsuleCollider>().enabled = true;
        allyPoints = transform.parent.GetComponent<AllyPointSetter>().allyPoints;
        foreach (AllyPoint allyPoint in allyPoints)
        {
            if (!allyPoint.AllyObject)
            {
                allyPoint.AllyObject = gameObject;
                GetComponent<MoveToTarget>().target = allyPoint.Point;
                levelManager.ChangeAllyCount(1);
                break;
            }
        }
    }
    public void LeaveTeam()
    {
        StartCoroutine(LeaveTeamCoroutine());   
    }
    IEnumerator LeaveTeamCoroutine()
    {
        this.transform.SetParent(pool.transform);
        GetComponent<CapsuleCollider>().enabled = false;
        //GetComponent<Animator>().SetTrigger("Fall");
        GetComponent<Move>().StopMoveToDirection();
        GetComponent<MovementClass>().StopMovement();
        levelManager.ChangeAllyCount(-1);

        foreach (AllyPoint allyPoint in allyPoints)
        {
            if (allyPoint.AllyObject == gameObject)
            {
                allyPoint.AllyObject = null;
                break;
            }
        }

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }

}

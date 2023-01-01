using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    void OnTriggerStay(Collider collidee){
        Debug.Log(collidee.tag);
        if(collidee.tag == "Ally"){
            collidee.transform.parent.GetComponent<Swipe>().enabled = false;
            MoveToPlayer(collidee.transform);
        }
    }
    void MoveToPlayer(Transform playerPos){
        for(int i = 1; i < transform.childCount; i++){
            transform.GetChild(i).GetComponent<EnemyMovement>().StopMovement();
            transform.GetChild(i).position = Vector3.MoveTowards(transform.GetChild(i).transform.position, playerPos.position, 5 * Time.deltaTime);
        }
    }
}

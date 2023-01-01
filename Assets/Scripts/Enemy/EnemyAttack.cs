using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool isFirst = false;
    void OnCollisionEnter(Collision collidee){
        Debug.Log(collidee.transform.tag);
        if(collidee.transform.tag == "Ally" && !isFirst){
            Debug.Log("HEHEHEH");
            collidee.transform.GetComponent<PartyMember>().LeaveParty();
            this.GetComponent<EnemyPartyMember>().LeaveParty();
            isFirst = true;
        }
    }
}

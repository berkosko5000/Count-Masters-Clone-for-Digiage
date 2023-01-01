using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool isFirst = false;
    void OnTriggerEnter(Collider collidee)
    {
        if (collidee.tag == "Ally" && !isFirst)
        {
            isFirst = true;
            if(collidee.GetComponent<PartyMember>().isDead == false){
                collidee.GetComponent<PartyMember>().LeaveParty();
                collidee.GetComponent<CapsuleCollider>().isTrigger = true;
                this.GetComponent<EnemyPartyMember>().LeaveParty();
                this.GetComponent<CapsuleCollider>().isTrigger = true;
            }
            
        }
    }
}

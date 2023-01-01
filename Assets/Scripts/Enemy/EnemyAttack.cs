using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool isFirst = false;
    void OnCollisionEnter(Collision collidee)
    {
        if (collidee.collider.tag == "Ally" && !isFirst)
        {
            isFirst = true;
            collidee.collider.GetComponent<PartyMember>().LeaveParty();
            this.GetComponent<EnemyPartyMember>().LeaveParty();
        }
    }
}

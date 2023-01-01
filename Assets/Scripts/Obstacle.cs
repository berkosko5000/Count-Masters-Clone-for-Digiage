using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider collidee)
    {
        if (collidee.tag == "Ally")
        {
            collidee.GetComponent<PartyMember>().LeaveParty();
        }
    }
}

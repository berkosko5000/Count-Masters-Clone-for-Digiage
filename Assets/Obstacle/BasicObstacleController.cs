using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collidee)
    {
        if (collidee.gameObject.tag == "Ally")
        {
            collidee.GetComponent<PartyMember>().LeaveParty();
        }
    }
}

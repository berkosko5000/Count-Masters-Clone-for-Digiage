using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject playerParty;
    private MovementDirection lastDirection;

    private void OnTriggerEnter(Collider colidee)
    {
        Vector3 current_pos = colidee.transform.position;
        current_pos.x = this.gameObject.transform.position.x;
        colidee.transform.position = current_pos;
        if (this.gameObject.tag == "LeftWall")
        {
            lastDirection = MovementDirection.Left;
        }
        else
        {
            lastDirection = MovementDirection.Right;
        }

    }
    private void OnTriggerStay(Collider colidee)
    {
        if (playerParty.GetComponent<PlayerPartyController>().movementDirection == lastDirection)
        {
            Vector3 current_pos = colidee.transform.position;
            current_pos.x = this.gameObject.transform.position.x;
            colidee.transform.position = current_pos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public int count = 1;
    [SerializeField] GameObject _clone;

    private void OnTriggerEnter(Collider other)
    {
        int magnitude = this.gameObject.GetComponent<Options>().optionMagnitude;
        ChannelType channelType = this.gameObject.GetComponent<Options>().channelType;
        Vector3 firstPos = other.gameObject.transform.position;
        Transform parent = other.transform.parent;
        float randomPositionRange = 0.5f;
        if (channelType == ChannelType.Multiplication)
        {
            count = count * magnitude;
        }

        else
        {
            count = count + magnitude;
        }
        for (int i = 0; i < count; i++)
            {
                Vector3 position = new Vector3(Random.Range(parent.position.x - randomPositionRange, parent.position.x + randomPositionRange),
                                                parent.position.y,
                                                Random.Range(parent.position.z - randomPositionRange, parent.position.z + randomPositionRange));

                GameObject ally = ObjectPooler.SharedInstance.GetPooledObject("Ally");
                ally.transform.position = position;
                ally.transform.SetParent(parent);
                ally.GetComponent<PartyMember>().JoinTeam();
                ally.SetActive(true);
            }
    }
}


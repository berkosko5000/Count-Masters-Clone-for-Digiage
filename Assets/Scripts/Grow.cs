using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{

    [SerializeField] Transform clonesTab;
    public int count = 1;
    [SerializeField] GameObject _clone;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Options>())
        {
            int magnitude = other.gameObject.GetComponent<Options>().optionMagnitude;
            bool operatorIsMultiplication = other.gameObject.GetComponent<Options>().isMultiplication;
            Vector3 firstPos = gameObject.transform.position;
            if (operatorIsMultiplication)
            {
                Multiply(magnitude, firstPos, count);
            }

            else
            {
                Add(magnitude, firstPos, count);
            }
        }

    }


    void Multiply(int magnitude, Vector3 firstPos, int count)
    {
        for (int i = 0; i < count * magnitude; i++)
        {
            GameObject temp = Instantiate(_clone, clonesTab);
            Destroy(temp.GetComponent<Grow>());
            temp.transform.position = new Vector3(firstPos.x+1,firstPos.y,firstPos.z-2);
        }
        count *= magnitude;
    }

    void Add(int magnitude, Vector3 firstPos, int count)
    {
        for (int i = 0; i < magnitude; i++)
        {
            GameObject temp = Instantiate(_clone, clonesTab);
            temp.transform.position = firstPos;
        }
        count += magnitude;
    }
}


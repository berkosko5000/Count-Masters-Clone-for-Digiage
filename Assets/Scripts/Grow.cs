using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Grow : MonoBehaviour
{

    [SerializeField] Transform clonesTab;
    public int count = 1;
    private void OnCollisionEnter(Collision collision)
    {
        int magnitude = collision.gameObject.GetComponent<Options>().optionMagnitude;
        bool operatorIsMultiplication = collision.gameObject.GetComponent<Options>().isMultiplication;
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

    void Multiply(int magnitude, Vector3 firstPos,int count)
    {
        for (int i = 0; i < count * magnitude; i++)
        {
            GameObject temp = Instantiate(gameObject, clonesTab);
            temp.transform.position = firstPos;
        }
        count *= magnitude;
    }

    void Add(int magnitude, Vector3 firstPos, int count)
    {
        for (int i = 0; i < magnitude; i++)
        {
            GameObject temp = Instantiate(gameObject, clonesTab);
            temp.transform.position = firstPos;
        }
        count += magnitude;
    }
}


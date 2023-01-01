using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] Button leftMovement, rightMovement;

    public float swipeSpeed = 10f;

    private void Start()
    {
        leftMovement.onClick.AddListener(MoveLeft);
        rightMovement.onClick.AddListener(MoveRight);
    }
    // Ekran�n sol ve sa� yar�s�na bas�l� tutulunca objenin kayd�r�lmas�n� ger�ekle�tir
    void MoveLeft()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.left * swipeSpeed;
    }

    void MoveRight()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.right * swipeSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * swipeSpeed * Time.deltaTime;
    }
}

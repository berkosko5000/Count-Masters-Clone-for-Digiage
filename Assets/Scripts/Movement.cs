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
    // Ekranýn sol ve sað yarýsýna basýlý tutulunca objenin kaydýrýlmasýný gerçekleþtir
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* public class Movement : MonoBehaviour
{
    [SerializeField] Button leftButton, rightButton;
    public bool isLeftPressed = false;
    public bool isRightPressed = false;

    public GameObject playerParty;

    public float swipeSpeed = 10f;
    public float forwardSpeed = 10f;

    private void Awake()
    {
        leftButton = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<Button>();
        rightButton = GameObject.FindGameObjectWithTag("RightButton").GetComponent<Button>();
        playerParty = GameObject.FindGameObjectWithTag("PlayerParty");
    }

    private void Start()
    {
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }
    // Ekran�n sol ve sa� yar�s�na bas�l� tutulunca objenin kayd�r�lmas�n� ger�ekle�tir
    void MoveLeft()
    {
        playerParty.GetComponent<PlayerPartyController>().movementDirection = MovementDirection.Left;
        this.GetComponent<Rigidbody>().velocity = Vector3.left * swipeSpeed;
    }

    void MoveRight()
    {
        playerParty.GetComponent<PlayerPartyController>().movementDirection = MovementDirection.Right;
        this.GetComponent<Rigidbody>().velocity = Vector3.right * swipeSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
} */

public class Swipe : Move
{
    [SerializeField] float swiperStopTolerance;
    [SerializeField] float endPointSpeed;
    Vector3 startPoint;
    Vector3 endPoint;
    float inputSpeed;
    Camera cam;

    void Start()
    {
        endPoint = Vector3.zero;
        cam = Camera.main;
    }
    public override Vector3 CalculateDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            endPoint = startPoint;
        }
        if (Input.GetMouseButton(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            inputSpeed = GetSwipeSpeed(startPoint.x, endPoint.x);
            endPoint = Vector3.Lerp(endPoint, startPoint, endPointSpeed * Time.deltaTime);
            return new Vector3(inputSpeed, 0, 0);
        }
        return Vector3.zero;
    }
    float GetSwipeSpeed(float startPoint, float endPoint)
    {
        float inputSpeed = startPoint - endPoint;
        if (Mathf.Abs(inputSpeed) > swiperStopTolerance)
        {
            return inputSpeed;
        }
        else
        {
            return 0;
        }
    }
}

using UnityEngine;

public abstract class Move : MonoBehaviour
{
    Vector3 direction;
    MovementClass movement;
    private void Awake()
    {
        movement = GetComponent<MovementClass>();
    }
    private void Update()
    {
        direction = CalculateDirection();
    }
    void FixedUpdate()
    {
        movement.Move(direction);
    }
    public void StartMoveToDirection()
    {
        enabled = true;
    }
    public void StopMoveToDirection()
    {
        enabled = false;
    }
    public abstract Vector3 CalculateDirection();
}
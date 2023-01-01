using UnityEngine;

public abstract class MovementClass : MonoBehaviour
{
    private void Awake()
    {
        StartMovement();
    }
    public abstract void Move(Vector3 direction);
    public abstract void StopMovement();
    public abstract void StartMovement();
}
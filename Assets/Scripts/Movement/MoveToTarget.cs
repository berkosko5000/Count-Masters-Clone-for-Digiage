using UnityEngine;

public class MoveToTarget : Move
{
    [HideInInspector] public Vector3 target;
    public override Vector3 CalculateDirection()
    {
        return target;
    }
}
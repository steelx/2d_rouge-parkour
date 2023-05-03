using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData", order = 1)]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxSpeed = 5f;

    [Range(0.1f, 100)]
    public float acceleration = 50f, deacceleration = 50f;
}

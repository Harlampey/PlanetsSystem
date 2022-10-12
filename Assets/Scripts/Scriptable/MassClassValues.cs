using UnityEngine;

[CreateAssetMenu(fileName = "MassClass", menuName = "ScriptableObjects/MassClass", order = 1)]
public class MassClassValues : ScriptableObject
{
    public float MinMass, MaxMass;
    public float MinRadius, MaxRadius;
}

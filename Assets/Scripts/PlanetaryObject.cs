using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(TrajectoryDrawer))]
public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    [SerializeField] private MassClassValues[] _massClassValues;
    [SerializeField] private MassClassValues _massClass;
    public MassClassEnum MassClassEnum { get; set; }
    public double Mass { get; set; }
    

    [SerializeField] private TrajectoryDrawer _drawer;
    private MassClass massClass;
    public float Speed;


    public void Initialize(double mass, float id)
    {
        MassClassEnum = new MassClassEnum(_massClassValues);

        Mass = mass;
        _massClass = GetMassClass(mass);
        transform.localScale = Vector3.one * Random.Range(_massClass.MinRadius, _massClass.MaxRadius) * 2;

        Speed = (float)Math.Pow(1.3, 1 / (id / 18));
    }

    private MassClassValues GetMassClass(double mass)
    {
        massClass = new MassClass(_massClassValues);
        foreach (MassClassValues massClass in massClass)
        {
            if (mass < massClass.MaxMass)
                return massClass;
        }

        throw new Exception("Invalid mass index");
    }

    public void DrawTrajectory()
    {
        _drawer.CreatePoints(transform.position.z);
    }
}

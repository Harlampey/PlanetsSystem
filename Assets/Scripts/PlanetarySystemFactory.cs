using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(PlanetarySystem))]
public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{   
    [SerializeField] private float _totalMass;
    [SerializeField] private float _offsetZ;
    [SerializeField] private GameObject _planetPrefab;

    private PlanetarySystem _planetarySystem;
    private List<PlanetaryObject> _objects;

    private int _objectId;
    private float _maxMass = 5000;

    private void Start()
    {
        _planetarySystem = GetComponent<PlanetarySystem>();

        CreatePlanets();
    }
    private void CreatePlanets()
    {
        _objects = new List<PlanetaryObject>();
        int count = 0;

        while (count < 10)
        {
            double mass = Mathf.Clamp(Random.Range(0f, _totalMass),0, _maxMass);
            _totalMass -= (float)mass;

            Create(mass);
            count++;
        }

        _planetarySystem.SetPlanetaryObjects(_objects.ToArray());
    }

    public void Create(double mass)
    {
        GameObject createdPlanet = Instantiate(_planetPrefab, transform.position, Quaternion.identity);
        PlanetaryObject planetaryObject = createdPlanet.GetComponent<PlanetaryObject>();

        _objectId++;
        planetaryObject.Initialize(mass, _objectId);

        if (_objects.Count > 0)
        {
            _offsetZ += planetaryObject.transform.localScale.z / 2 + _objects.Last().transform.localScale.z / 2;
        } else
        {
            _offsetZ += planetaryObject.transform.localScale.z / 2;
        }

        createdPlanet.transform.position = new Vector3(0, 0, _offsetZ);
        planetaryObject.DrawTrajectory();
        _objects.Add(planetaryObject);
    }
}

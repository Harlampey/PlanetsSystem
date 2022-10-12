using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    public IEnumerable<PlanetaryObject> PlanetaryObjects { get; set; }

    private void Update()
    {
        Update(Time.deltaTime);
    }

    public void SetPlanetaryObjects(PlanetaryObject[] objects)
    {
        PlanetaryObjects = objects;
    }

    public void Update(float deltaTime)
    {
        foreach (PlanetaryObject obj in PlanetaryObjects)
        {
            obj.transform.RotateAround(Vector3.zero, Vector3.up, deltaTime * obj.Speed);
        }
    }

}

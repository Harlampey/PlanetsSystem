using System.Collections.Generic;

public interface IPlanetarySystem
{
    public IEnumerable<PlanetaryObject> PlanetaryObjects { get; set; }
    public void Update(float deltaTime);
}

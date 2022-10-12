using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private void Start()
    {
        GetComponent<Renderer>().material = _materials[Random.Range(0, _materials.Length)];
    }
}

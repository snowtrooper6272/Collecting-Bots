using UnityEngine;

[CreateAssetMenu(fileName = "New SOResource", menuName = "Resource/Create new resource", order = 51)]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private Material _material;
    [SerializeField] private int _chance;

    public int Price => _price;
    public int Chance => _chance;
    public Material Material => _material;
}

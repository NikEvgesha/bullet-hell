using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private int _wood = 0;
    private int _stone = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddResource(ResourceType type, int amount)
    {
        if (type == ResourceType.Wood) _wood += amount;
        if (type == ResourceType.Stone) _stone += amount;

        Debug.Log($"Дерево: {_wood}, Камень: {_stone}");
    }
}

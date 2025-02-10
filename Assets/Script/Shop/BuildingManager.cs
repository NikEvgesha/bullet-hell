using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager Instance;
    public GameObject BuildingPrefab;
    private void Awake()
    {
        Instance = this;
    }
    public void Build(Vector3 position)
    {
        if (PlayerStats.Instance.HasResources(10, 5))
        {
            PlayerStats.Instance.SpendResources(10, 5);
            Instantiate(BuildingPrefab, position, Quaternion.identity);
            Debug.Log("Здание построено!");
        }
        else
        {
            Debug.Log("Недостаточно ресурсов для строительства!");
        }
    }
}

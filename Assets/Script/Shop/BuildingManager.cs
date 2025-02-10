using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject BuildingPrefab;

    public void Build(Vector3 position)
    {
        if (PlayerStats.Instance.HasResources(10, 5))
        {
            PlayerStats.Instance.SpendResources(10, 5);
            Instantiate(BuildingPrefab, position, Quaternion.identity);
            Debug.Log("������ ���������!");
        }
        else
        {
            Debug.Log("������������ �������� ��� �������������!");
        }
    }
}

using UnityEngine;

public class Building : MonoBehaviour
{
    public string BuildingName;
    public int WoodCost = 10;
    public int StoneCost = 5;
    public int Level = 1;

    public void Upgrade()
    {
        if (PlayerStats.Instance.HasResources(WoodCost, StoneCost))
        {
            PlayerStats.Instance.SpendResources(WoodCost, StoneCost);
            Level++;
            WoodCost += 5; // Увеличиваем цену улучшения
            StoneCost += 3;
            Debug.Log($"{BuildingName} улучшено до уровня {Level}!");
        }
        else
        {
            Debug.Log("Недостаточно ресурсов!");
        }
    }
}

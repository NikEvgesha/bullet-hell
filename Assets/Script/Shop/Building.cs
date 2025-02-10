using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private UseArea UseArea;
    public string BuildingName;
    public int WoodCost = 10;
    public int StoneCost = 5;
    public int Level = 1;
    private void Awake()
    {
        if (UseArea == null)
        {
            UseArea = GetComponentInChildren<UseArea>();
        }
        UseArea.StateTrigger += CheckTrigger;
    }
    private void CheckTrigger(bool state)
    {
        if (state)
        {
            Upgrade();
        }
    }
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

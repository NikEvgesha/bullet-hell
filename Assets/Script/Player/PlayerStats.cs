using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private int _gold = 0;
    private int _exp = 0;
    private int _level = 1;
    private int _expToNextLevel = 10;

    private Dictionary<string, int> _resources = new Dictionary<string, int>();

    void Awake()
    {
        Instance = this;
    }

    public void AddResource(string type, int amount)
    {
        if (!_resources.ContainsKey(type))
        {
            _resources[type] = 0;
        }
        _resources[type] += amount;
        Debug.Log($"{type}: {_resources[type]}");
    }
    public bool HasResources(int wood, int stone)
    {
        return _resources.ContainsKey("Wood") && _resources["Wood"] >= wood &&
               _resources.ContainsKey("Stone") && _resources["Stone"] >= stone;
    }

    public void SpendResources(int wood, int stone)
    {
        if (HasResources(wood, stone))
        {
            _resources["Wood"] -= wood;
            _resources["Stone"] -= stone;
            Debug.Log($"������� ���������! ������: {_resources["Wood"]}, ������: {_resources["Stone"]}");
        }
    }

    public void AddGold(int amount)
    {
        _gold += amount;
        Debug.Log($"������: {_gold}");
    }

    public bool TrySpendGold(int amount)
    {
        if (_gold >= amount)
        {
            _gold -= amount;
            Debug.Log($"������: {_gold}");
            return true;
        }
        return false;
    }

    public void AddExp(int amount)
    {
        _exp += amount;
        Debug.Log($"����: {_exp}/{_expToNextLevel}");

        while (_exp >= _expToNextLevel)
        {
            _exp -= _expToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _expToNextLevel += 5; // ����������� ���������� ��� ���������� ������
        Debug.Log($" ����� �������: {_level}! ������, ��� ��������.");

        // TODO: � ������� �������� ����� ���������
    }
}

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
            Debug.Log($"Ресурсы потрачены! Дерево: {_resources["Wood"]}, Камень: {_resources["Stone"]}");
        }
    }

    public void AddGold(int amount)
    {
        _gold += amount;
        Debug.Log($"Золото: {_gold}");
    }

    public bool TrySpendGold(int amount)
    {
        if (_gold >= amount)
        {
            _gold -= amount;
            Debug.Log($"Золото: {_gold}");
            return true;
        }
        return false;
    }

    public void AddExp(int amount)
    {
        _exp += amount;
        Debug.Log($"Опыт: {_exp}/{_expToNextLevel}");

        while (_exp >= _expToNextLevel)
        {
            _exp -= _expToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _expToNextLevel += 5; // Увеличиваем требования для следующего уровня
        Debug.Log($" Новый уровень: {_level}! Выбери, что улучшить.");

        // TODO: В будущем добавить выбор улучшений
    }
}

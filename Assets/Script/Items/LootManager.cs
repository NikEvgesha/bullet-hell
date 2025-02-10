using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager Instance;
    public GameObject LootPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnLoot(Vector3 position, int gold, int exp)
    {
        GameObject loot = Instantiate(LootPrefab, position, Quaternion.identity);
        loot.GetComponent<Loot>().SetValues(gold, exp);
    }
}

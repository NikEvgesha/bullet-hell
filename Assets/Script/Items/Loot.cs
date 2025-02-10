using UnityEngine;

public class Loot : MonoBehaviour
{
    public int GoldAmount { get; private set; }
    public int ExpAmount { get; private set; }

    public void SetValues(int gold, int exp)
    {
        GoldAmount = gold;
        ExpAmount = exp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.Instance.AddGold(GoldAmount);
            PlayerStats.Instance.AddExp(ExpAmount);
            Destroy(gameObject);
        }
    }
}

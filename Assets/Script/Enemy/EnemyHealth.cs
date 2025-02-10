using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 30;
    public int GoldReward = 10;
    public int ExpReward = 5;
    public int Level = 1;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        int totalExp = ExpReward + (Level * 2); // Больше опыта с сильных врагов
        LootManager.Instance.SpawnLoot(transform.position, GoldReward, totalExp);
        Destroy(gameObject);
    }
}

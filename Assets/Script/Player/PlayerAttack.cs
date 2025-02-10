using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float AttackRange = 1.5f; // Дальность удара
    public int AttackDamage = 10; // Урон
    public float AttackCooldown = 0.5f; // Задержка между ударами
    public LayerMask EnemyLayer; // Слой врагов

    private float _nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= _nextAttackTime)
        {
            Attack();
            _nextAttackTime = Time.time + AttackCooldown;
        }
    }

    void Attack()
    {
        // Проверяем врагов
        Collider[] hitObjects = Physics.OverlapSphere(transform.position + transform.forward * AttackRange, AttackRange);

        foreach (Collider obj in hitObjects)
        {
            if (obj.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(AttackDamage);
            }
            else if (obj.TryGetComponent<Resource>(out Resource resource))
            {
                resource.Harvest();
            }
        }
    }

    // Включаем отладочную визуализацию атаки
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * AttackRange, AttackRange);
    }
}

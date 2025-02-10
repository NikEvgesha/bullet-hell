using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float AttackRange = 1.5f; // ��������� �����
    public int AttackDamage = 10; // ����
    public float AttackCooldown = 0.5f; // �������� ����� �������
    public LayerMask EnemyLayer; // ���� ������

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
        // ��������� ������
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

    // �������� ���������� ������������ �����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * AttackRange, AttackRange);
    }
}

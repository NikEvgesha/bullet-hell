using UnityEngine;

public class Resource : MonoBehaviour
{
    public int ResourceAmount = 5; // ������� �������� ���� ������
    public ResourceType Type; // ��� ������� (������/������)

    public void Harvest()
    {
        ResourceManager.Instance.AddResource(Type, ResourceAmount);
        Gather();
        //Destroy(gameObject);
    }
    public void Gather()
    {
        if (ResourceAmount > 0)
        {
            ResourceAmount--;
            PlayerStats.Instance.AddResource(Type.ToString(), 1);

            if (ResourceAmount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

public enum ResourceType { Wood, Stone }

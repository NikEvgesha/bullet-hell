using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShopUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShopUI.SetActive(false);
        }
    }
}

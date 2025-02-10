using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public string ItemName;
    public int Price;
    public Button BuyButton;

    void Start()
    {
        BuyButton.onClick.AddListener(BuyItem);
    }

    void BuyItem()
    {
        if (PlayerStats.Instance.TrySpendGold(Price))
        {
            Inventory.Instance.AddItem(ItemName);
            Debug.Log($"{ItemName} куплен!");
        }
        else
        {
            Debug.Log("Недостаточно золота!");
        }
    }
}

using UnityEngine;

public class BuyPoint : MonoBehaviour
{
    [SerializeField] private UseArea UseArea;
    [SerializeField] private Transform buildPosition;
    private void Awake()
    {
        if (UseArea == null)
        {
            UseArea = GetComponentInChildren<UseArea>();
        }
        UseArea.StateTrigger += CheckTrigger;
    }
    private void CheckTrigger(bool state)
    {
        if (state)
        {
            BuildingManager.Instance.Build(buildPosition.position);
        }
    }
}

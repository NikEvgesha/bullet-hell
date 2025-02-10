using System;
using UnityEngine;

public class UseArea : MonoBehaviour
{
    public Action<bool> StateTrigger;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StateTrigger?.Invoke(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StateTrigger?.Invoke(false);
        }
    }
}

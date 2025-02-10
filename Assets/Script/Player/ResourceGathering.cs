using UnityEngine;

public class ResourceGathering : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Удар (можно заменить на анимацию)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.collider.GetComponent<Resource>() != null)
                {
                    hit.collider.GetComponent<Resource>().Gather();
                }
            }
        }
    }
}

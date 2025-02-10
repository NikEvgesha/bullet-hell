using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Персонаж
    public Vector3 offset = new Vector3(0, 3, -5); // Смещение камеры
    public float smoothSpeed = 5f; // Скорость следования

    void LateUpdate()
    {
        if (target == null) return;

        // Плавное следование за персонажем
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Поворот камеры за персонажем
        transform.LookAt(target);
    }
}

// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; // Смещение камеры от корабля
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset; // Вычисляем желаемую позицию камеры с учетом смещения
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime); // Обновляем позицию камеры с помощью интерполяции
        }
    }
}
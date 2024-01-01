using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на игрока

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(0f, 2f, -5f);
            transform.LookAt(target);
        }
    }
}


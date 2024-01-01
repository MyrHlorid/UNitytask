using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject cubePrefab; // Префаб куба
    public Material greenMaterial; // Материал для зеленого цвета

    public Transform spawnPoint; // Ссылка на точку появления куба

    private GameObject spawnedCube; // Созданный куб
    private bool cubeSpawned = false; // Флаг для отслеживания создания куба
    private float growthTime = 10f; // Время роста в секундах
    private bool cubeGrown = false; // Флаг для отслеживания роста куба

    void Update()
    {
        // Проверка нажатия кнопки E
        if (Input.GetKeyDown(KeyCode.E) && !cubeSpawned)
        {
            SpawnCube();
        }

        // Проверка времени роста куба
        if (cubeSpawned && !cubeGrown)
        {
            growthTime -= Time.deltaTime;

            if (growthTime <= 0f)
            {
                GrowCube();
            }
        }

        // Проверка нажатия кнопки R
        if (Input.GetKeyDown(KeyCode.R) && cubeSpawned && cubeGrown)
        {
            DestroyCube();
        }
    }

    // Создание куба
    void SpawnCube()
    {
        spawnedCube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);
        cubeSpawned = true;
    }

    // Рост куба и изменение цвета
    void GrowCube()
    {
        if (spawnedCube != null)
        {
            spawnedCube.transform.localScale *= 2f; // Увеличение размера в 2 раза
            spawnedCube.GetComponent<Renderer>().material = greenMaterial; // Установка зеленого материала
            cubeGrown = true;
        }
    }

    // Уничтожение куба
    void DestroyCube()
    {
        if (spawnedCube != null)
        {
            Destroy(spawnedCube);
            cubeSpawned = false;
            cubeGrown = false;
            growthTime = 10f;
        }
    }
}
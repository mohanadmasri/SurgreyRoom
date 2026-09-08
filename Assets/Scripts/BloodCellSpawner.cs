using UnityEngine;

public class BloodCellSpawner : MonoBehaviour
{
    [Header("Blood Cell")]
    [SerializeField] private GameObject bloodCellPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private int numberOfCells = 12;
    [SerializeField] private float startDistance = 2f;
    [SerializeField] private float endDistance = 12f;

    [Header("Spawn Area")]
    [SerializeField] private float horizontalRange = 0.2f;
    [SerializeField] private float verticalRange = 0.15f;

    [Header("Path Direction")]
    [SerializeField] private float pathDirection = 1f;

    void Start()
    {
        SpawnBloodCells();
    }

    void SpawnBloodCells()
    {
        if (bloodCellPrefab == null)
            return;

        for (int i = 0; i < numberOfCells; i++)
        {
            float t = numberOfCells == 1
                ? 0f
                : (float)i / (numberOfCells - 1);

            float distance =
                Mathf.Lerp(startDistance, endDistance, t);

            float yOffset =
                Random.Range(-verticalRange, verticalRange);

            float zOffset =
                Random.Range(-horizontalRange, horizontalRange);

            Vector3 spawnPosition =
                transform.position
                + Vector3.right * distance * pathDirection
                + Vector3.up * yOffset
                + Vector3.forward * zOffset;

            Instantiate(
                bloodCellPrefab,
                spawnPosition,
                Random.rotation
            );
        }
    }
}
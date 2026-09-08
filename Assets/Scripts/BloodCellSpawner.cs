using UnityEngine;

public class BloodCellSpawner : MonoBehaviour
{
    [Header("Blood Cell")]
    [SerializeField] private GameObject bloodCellPrefab;

    [Header("Direction")]
    [SerializeField] private Transform directionReference;

    [Header("Spawn Settings")]
    [SerializeField] private int numberOfCells = 12;
    [SerializeField] private float startDistance = 2f;
    [SerializeField] private float endDistance = 12f;

    [Header("Spawn Area")]
    [SerializeField] private float horizontalRange = 0.3f;
    [SerializeField] private float verticalRange = 0.3f;

    void Start()
    {
        SpawnBloodCells();
    }

    void SpawnBloodCells()
    {
        if (bloodCellPrefab == null || directionReference == null)
            return;

        for (int i = 0; i < numberOfCells; i++)
        {
            // توزيع منتظم على طول المسار
            float t = numberOfCells == 1
                ? 0f
                : (float)i / (numberOfCells - 1);

            float distance = Mathf.Lerp(
                startDistance,
                endDistance,
                t
            );

            // اختلاف بسيط حتى لا يكونوا على خط واحد
            float sideOffset =
                Random.Range(-horizontalRange, horizontalRange);

            float verticalOffset =
                Random.Range(-verticalRange, verticalRange);

            Vector3 spawnPosition =
                transform.position
                + directionReference.right * distance
                + directionReference.forward * sideOffset
                + directionReference.up * verticalOffset;

            Instantiate(
                bloodCellPrefab,
                spawnPosition,
                Random.rotation
            );
        }
    }
}
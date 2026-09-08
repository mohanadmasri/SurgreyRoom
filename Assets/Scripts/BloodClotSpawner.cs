using UnityEngine;

public class BloodClotSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject bloodCellPrefab;

    [Header("Clot Settings")]
    public int numberOfCells = 35;
    public float clotRadius = 0.18f;
    public float pathThickness = 0.08f;
    public float verticalOffset = -0.15f;

    [Header("Cell Scale")]
    public float minScale = 0.75f;
    public float maxScale = 0.95f;

    [Header("Cleanup")]
    public bool clearOldChildren = true;

    void Start()
    {
        GenerateClot();
    }

    [ContextMenu("Generate Clot")]
    public void GenerateClot()
    {
        if (bloodCellPrefab == null)
        {
            Debug.LogWarning("Blood Cell Prefab is missing!");
            return;
        }

        if (clearOldChildren)
        {
            ClearClot();
        }

        for (int i = 0; i < numberOfCells; i++)
        {
            GameObject cell = Instantiate(
                bloodCellPrefab,
                transform
            );

            Vector3 offset =
                Random.insideUnitSphere * clotRadius;

            // يخلي التجلط أضيق على محور المسار
            offset.x *= pathThickness;

            // ينزل التجلط شوي
            offset.y += verticalOffset;

            cell.transform.localPosition = offset;
            cell.transform.localRotation = Random.rotation;

            float scale =
                Random.Range(minScale, maxScale);

            cell.transform.localScale =
                Vector3.one * scale;

            // نخلي خلايا التجلط ثابتة
            BloodCellMovement movement =
                cell.GetComponent<BloodCellMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }
        }
    }

    [ContextMenu("Clear Clot")]
    public void ClearClot()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(
                transform.GetChild(i).gameObject
            );
        }
    }
}
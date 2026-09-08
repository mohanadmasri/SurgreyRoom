using UnityEngine;

public class BloodCellMovement : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 30f;

    [Header("Floating")]
    [SerializeField] private float floatAmount = 0.1f;
    [SerializeField] private float floatSpeed = 1f;

    [Header("Movement Limits")]
    [SerializeField] private float minSide = -0.3f;
    [SerializeField] private float maxSide = 0.3f;

    [SerializeField] private float minHeight = -0.2f;
    [SerializeField] private float maxHeight = 0.2f;

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // دوران
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.Self
        );

        // طفو بسيط
        float sideOffset =
            Mathf.Sin(Time.time * floatSpeed + randomOffset)
            * floatAmount;

        float heightOffset =
            Mathf.Cos(Time.time * floatSpeed + randomOffset)
            * floatAmount;

        sideOffset = Mathf.Clamp(
            sideOffset,
            minSide,
            maxSide
        );

        heightOffset = Mathf.Clamp(
            heightOffset,
            minHeight,
            maxHeight
        );

        transform.position =
            startPosition
            + Vector3.forward * sideOffset
            + Vector3.up * heightOffset;
    }
}
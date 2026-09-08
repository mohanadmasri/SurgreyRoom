using UnityEngine;

public class BloodCellMovement : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 30f;

    [Header("Floating")]
    [SerializeField] private float floatAmount = 0.15f;
    [SerializeField] private float floatSpeed = 1.5f;

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // دوران بسيط
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.Self
        );

        // حركة طفو بسيطة
        float yOffset =
            Mathf.Sin(Time.time * floatSpeed + randomOffset)
            * floatAmount;

        transform.position =
            startPosition + Vector3.up * yOffset;
    }
}
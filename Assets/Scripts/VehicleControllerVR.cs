using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleControllerVR : MonoBehaviour
{
    [Header("Vehicle Direction")]
    [SerializeField] private Transform vehicleModel;

    [Header("Movement Speed")]
    [SerializeField] private float forwardSpeed = 1.5f;
    [SerializeField] private float horizontalSpeed = 1f;
    [SerializeField] private float verticalSpeed = 1f;

    [Header("Movement Limits")]
    [SerializeField] private float minSide = -0.8f;
    [SerializeField] private float maxSide = 0.8f;

    [SerializeField] private float minHeight = -0.5f;
    [SerializeField] private float maxHeight = 0.5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (vehicleModel == null)
            return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed)
            {
                horizontal = -1f;
            }

            if (Keyboard.current.dKey.isPressed ||
                Keyboard.current.rightArrowKey.isPressed)
            {
                horizontal = 1f;
            }

            if (Keyboard.current.wKey.isPressed ||
                Keyboard.current.upArrowKey.isPressed)
            {
                vertical = 1f;
            }

            if (Keyboard.current.sKey.isPressed ||
                Keyboard.current.downArrowKey.isPressed)
            {
                vertical = -1f;
            }
        }

        Vector3 movement =
            vehicleModel.forward * forwardSpeed +
            vehicleModel.right * horizontal * horizontalSpeed +
            vehicleModel.up * vertical * verticalSpeed;

        transform.position += movement * Time.deltaTime;

        Vector3 localOffset = transform.position - startPosition;

        float side =
            Vector3.Dot(localOffset, vehicleModel.right);

        float height =
            Vector3.Dot(localOffset, vehicleModel.up);

        side = Mathf.Clamp(side, minSide, maxSide);
        height = Mathf.Clamp(height, minHeight, maxHeight);

        float forward =
            Vector3.Dot(localOffset, vehicleModel.forward);

        transform.position =
            startPosition +
            vehicleModel.forward * forward +
            vehicleModel.right * side +
            vehicleModel.up * height;
    }
}
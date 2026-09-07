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

    void Update()
    {
        if (vehicleModel == null)
            return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current != null)
        {
            // Left and right
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

            // Up and down
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
    }
}
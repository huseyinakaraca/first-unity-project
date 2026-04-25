using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float heightOffset = 1f;
    public float sensitivity = 3f; 
    float yaw = 0f;  
    float pitch = 0f; 
    public float smoothSpeed = 10f;
    Vector3 currentRotation;
    Vector3 smoothVelocity = Vector3.zero;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -15f, 60f);
        Vector3 targetRotation = new Vector3(pitch, yaw, 0f);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref smoothVelocity, 1f / smoothSpeed);
        transform.eulerAngles = currentRotation;
        transform.position = target.position + (Vector3.up * heightOffset) - (transform.forward * distance);
    }
}
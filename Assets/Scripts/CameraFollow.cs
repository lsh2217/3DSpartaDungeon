using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("Look")]
    public Transform target;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    private float camCurYRot;
    public float lookSensitivity;
    public float distance;
    public float height;

    private Vector2 mouseDelta;

    private void LateUpdate()
    {
        FollowTarget();
        CameraLook();
    }
    private void FollowTarget()
    {
        Quaternion rotation = Quaternion.Euler(camCurXRot, camCurYRot, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = target.position + offset + Vector3.up * height;

        transform.LookAt(target.position + Vector3.up * height);
    }

    void CameraLook()
    {
        camCurYRot += mouseDelta.x * lookSensitivity * Time.deltaTime;
        camCurXRot -= mouseDelta.y * lookSensitivity * Time.deltaTime;

        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}

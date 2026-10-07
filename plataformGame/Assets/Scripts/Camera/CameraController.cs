using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraSpeed = 2.5f;
    [SerializeField] private float downLimit = -8f, upLimit = 6f, leftLimit = -11f, rightLimit = 14f;
    private Vector3 position;

    private void Awake()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

    private void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);
        position.y = Mathf.Clamp(position.y, downLimit, upLimit);

        transform.position = Vector3.Lerp(transform.position, position, cameraSpeed * Time.deltaTime);
    }
}

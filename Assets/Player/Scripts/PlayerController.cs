using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera _camera;

    private GameManager _gameManager;

    public float mouseSensitivity = 100f;

    private float mouseX = 0f;
    private float mouseY = 0f;
    private float xRotation = 0f;

    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.GameStart)
        {
            mouseSensitivity = _gameManager.GetMouseSpeed() * 100;
            CameraMovement();
            TryToKill();
        }
    }

    private void TryToKill()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Target"))
                {
                    Destroy(hit.collider.gameObject);

                    Score.instance.AddKill();
                    Score.instance.RemoveOneFromTotalSpawnedTargets();
                    SoundManager.instance.PlayHitSound();

                    return;
                }
            }
            Score.instance.AddMiss();
        }
    }

    private void CameraMovement()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}

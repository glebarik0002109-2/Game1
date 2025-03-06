using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Чувствительность мыши
    public Transform playerBody; // Ссылка на объект игрока
    private float xRotation = 0f; // Угол поворота по оси X

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Скрыть курсор и заблокировать его в центре экрана
    }

    void Update()
    {
        // Получение ввода мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Поворот камеры по оси Y
        playerBody.Rotate(Vector3.up * mouseX);

        // Ограничение угла поворота по оси X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Ограничение угла наклона

        // Применение поворота к камере
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}


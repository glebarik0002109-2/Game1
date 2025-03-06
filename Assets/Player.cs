using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Максимальная скорость движения игрока
    public float sprintSpeedMultiplier = 2f; // Множитель скорости при спринте
    public float acceleration = 10f; // Ускорение
    public Camera playerCamera; // Ссылка на камеру
    private float currentSpeed = 0f; // Текущая скорость игрока

    void Update()
    {
        // Получение ввода от пользователя
        float horizontal = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float vertical = Input.GetAxis("Vertical"); // W/S или стрелки вверх/вниз

        // Получение направления вперед и вправо от камеры
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // Убираем вертикальную составляющую
        forward.y = 0;
        right.y = 0;

        // Нормализация векторов
        forward.Normalize();
        right.Normalize();

        // Создание вектора движения
        Vector3 movement = (forward * vertical + right * horizontal).normalized;

        // Если есть ввод, увеличиваем текущую скорость
        if (movement.magnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime; // Увеличиваем скорость
            currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed); // Ограничиваем максимальную скорость

            // Проверка нажатия клавиши Shift для спринта
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= sprintSpeedMultiplier; // Увеличиваем скорость при спринте
            }
        }
        else
        {
            currentSpeed = 0; // Сбрасываем скорость, если нет ввода
        }

        // Перемещение игрока с учетом текущей скорости
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
    }
}


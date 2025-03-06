using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ игрока
    public float stoppingDistance = 1.5f; // Расстояние, на котором противник остановится от игрока
    private NavMeshAgent navMeshAgent; // Ссылка на NavMeshAgent

    void Start()
    {
        // Получаем компонент NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Проверяем, есть ли ссылка на игрока
        if (player != null)
        {
            // Вычисляем расстояние до игрока
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Если противник находится дальше, чем stoppingDistance, движемся к игроку
            if (distanceToPlayer > stoppingDistance)
            {
                // Устанавливаем цель для NavMeshAgent
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                // Останавливаемся, когда находимся на нужном расстоянии
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}

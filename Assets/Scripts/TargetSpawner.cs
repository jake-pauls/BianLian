using UnityEngine;

/// <summary>
/// Manager class that spawns targets on the rhythm track.
/// </summary>
public class TargetSpawner : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("The prefab that the manager will spawn when the cooldown elapses.")]
    private GameObject m_TargetPrefab;
    
    [SerializeField] 
    [Tooltip("The position where the manager will spawn new targets.")]
    private Transform m_SpawnPoint;

    [SerializeField]
    [Min(0.5f)]
    [Tooltip("The amount of time in-between each target is spawned by the manager, in seconds.")]
    private float m_SpawnCooldown;
    
    private float m_CurrentTime;

    private void Awake()
    {
        if (m_TargetPrefab is null)
            Debug.LogWarning("No target prefab has been set for the rhythm manager!");

        if (m_SpawnPoint is null)
            Debug.LogWarning("No spawn point has been set for the rhythm manager!");

        m_CurrentTime = m_SpawnCooldown;
    }

    private void Update()
    {
        m_CurrentTime -= Time.deltaTime;

        // Spawn a target on the track when the timer runs out.
        if (m_CurrentTime <= 0.0f)
        {
            Instantiate(m_TargetPrefab, m_SpawnPoint);
            m_CurrentTime = m_SpawnCooldown;
        }
    }
}
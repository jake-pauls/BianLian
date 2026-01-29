using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Player controller that attempts to score points from targets on the rhythm track.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // TODO: It's kind of weird that the player tells the target to die and invokes target killed events. We could
    // try to separate these concerns. However, if we do this the other way every target would have to check if the
    // player killed them.
    //
    // (¬_¬")
    public UnityEvent OnTargetHit; 
    
    [SerializeField] 
    private CircleCollider2D m_ControllerCircleCollider;
    
    [SerializeField] 
    [Tooltip("The input action used to attempt to score in the event of a target overlap.")]
    private InputAction m_PlayerScoreInput;
    
    private void OnEnable()
        => m_PlayerScoreInput.Enable();

    private void OnDisable()
        => m_PlayerScoreInput.Disable();

    private void Update()
    {
        if (!m_PlayerScoreInput.WasPressedThisFrame())
            return;
        
        List<Collider2D> colliders = new();
        int hits = m_ControllerCircleCollider.Overlap(colliders);
        if (hits > 0)
        {
            // Take the first collider since only one target should be intersected at a time. 
            Collider2D intersectedCollider = colliders.First();
            
            // Destroy the intersected target game object and broadcast that a target was hit.
            Destroy(intersectedCollider.gameObject);
            OnTargetHit?.Invoke();
        }
    }
}

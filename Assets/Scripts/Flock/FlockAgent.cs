using UnityEngine;

namespace Flock
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgent : MonoBehaviour
    {
        private FlockController agentFlock;
        public FlockController AgentFlock => agentFlock;
        
        private Collider2D _agentCollider;
        public Collider2D AgentCollider => _agentCollider;

        private SpriteRenderer _agentSprite;
        public SpriteRenderer AgentSprite => _agentSprite;
        // Start is called before the first frame update
        private void Start()
        {
            _agentCollider = GetComponent<Collider2D>();
            _agentSprite = GetComponentInChildren<SpriteRenderer>();
        }


        public void Initialize(FlockController flock)
        {
            agentFlock = flock;
        }
        
        public void Move(Vector2 velocity)
        {
            transform.up = velocity;
            transform.position += (Vector3) velocity * Time.deltaTime;
        }

    }
}

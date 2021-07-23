using System.Collections.Generic;
using UnityEngine;

namespace Flock
{
    public class FlockController : MonoBehaviour
    {
        [SerializeField] private FlockBehavior behaviour;
        [SerializeField] private FlockPool pool;
        
        [Range(1f, 100f)] 
        [SerializeField] private float driveFactor = 10f;
        [Range(1f, 100f)]
        [SerializeField] private float maxSpeed = 5f;
        [Range(1f,10f)]
        [SerializeField] private float neighborRadius = 1.5f;
        [Range(0f,1f)]
        [SerializeField] private float avoidanceRadiusMultiplier = 0.5f;

        private float _squareMaxSpeed;
        private float _squareNeighborRadius;
        private float _squareAvoidanceRadius;
        public float SquareAvoidanceRadius => _squareAvoidanceRadius;
        
        // Start is called before the first frame update
        private void Start()
        {
            _squareMaxSpeed = maxSpeed * maxSpeed;
            _squareNeighborRadius = neighborRadius * neighborRadius;
            _squareAvoidanceRadius = avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            pool.SpawnFlock();
            
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (FlockAgent agent in pool.agents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                //agent.AgentSprite.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

                Vector2 move = behaviour.CalculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > _squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
            }
        }

        List<Transform> GetNearbyObjects(FlockAgent agent)
        {
            List<Transform> context = new List<Transform>();
            Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

            foreach (Collider2D c in contextColliders)
            {
                if (c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }
            
            return context;
        }
        
    }
}

using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Flock
{
    public class FlockPool : MonoBehaviour
    {
        
        [SerializeField] private FlockAgent agentPrefab;
        [HideInInspector] public List<FlockAgent> agents = new List<FlockAgent>();

        private FlockController _flockcontroller;
        
        [Range(10, 500)]
        [SerializeField] private int startingCount = 20;
        private const float AgentDensity = 0.08f;


        private void Awake()
        {
            _flockcontroller = GetComponentInParent<FlockController>();
        }

        public void SpawnFlock()
        {
            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    Random.insideUnitCircle * startingCount * AgentDensity,
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                    transform
                );
                newAgent.name = "Agent" + i;
                newAgent.Initialize(_flockcontroller);
                agents.Add(newAgent);
            }
        }
    }
}

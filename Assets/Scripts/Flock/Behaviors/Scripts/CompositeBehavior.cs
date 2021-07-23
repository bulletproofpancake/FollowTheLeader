using System.Collections.Generic;
using UnityEngine;

namespace Flock.Behaviors.Scripts
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Composite", fileName = "Composite")]
    public class CompositeBehavior : FlockBehavior
    {

        public FlockBehavior[] behaviors;
        public float[] weights;
        
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockController flockController)
        {
            // handle data mismatch
            if (weights.Length != behaviors.Length)
            {
                Debug.LogError("Data Mismatch in " + name, this);
                return Vector2.zero;
            }
            
            // set up move
            Vector2 move = Vector2.zero;
            
            // iterate through behaviours
            for (int i = 0; i < behaviors.Length; i++)
            {
                Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flockController) * weights[i];

                if (partialMove != Vector2.zero)
                {
                    if (partialMove.sqrMagnitude > weights[i]*weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    move += partialMove;
                }
                
            }

            return move;
        }
    }
}

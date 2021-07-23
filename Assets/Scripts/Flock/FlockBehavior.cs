using System.Collections.Generic;
using UnityEngine;

namespace Flock
{
    public abstract class FlockBehavior : ScriptableObject
    {
        public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockController flockController);
    }
}

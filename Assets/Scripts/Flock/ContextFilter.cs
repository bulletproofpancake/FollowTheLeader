using System.Collections.Generic;
using UnityEngine;

namespace Flock
{
    public abstract class ContextFilter : ScriptableObject
    {
        public abstract List<Transform> Filter(FlockAgent agent, List<Transform> original);
    }
}

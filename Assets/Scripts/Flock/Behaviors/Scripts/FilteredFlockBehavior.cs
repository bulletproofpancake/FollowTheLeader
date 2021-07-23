using System.Collections.Generic;
using UnityEngine;

namespace Flock.Behaviors.Scripts
{
    public abstract class FilteredFlockBehavior : FlockBehavior
    {
        public ContextFilter filter;
    }
}

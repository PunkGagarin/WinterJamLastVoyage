using System.Linq;
using Core.Events.GameEvents.PhysEvents;
using UnityEngine;

namespace Core.Events.Pools {

    public class GameEventPool : BasePool<BasePhysicalEvent> {

        public override void InitPool() {
            _events = Resources.LoadAll<BasePhysicalEvent>("Events/Time").ToList();
        }
    }

}
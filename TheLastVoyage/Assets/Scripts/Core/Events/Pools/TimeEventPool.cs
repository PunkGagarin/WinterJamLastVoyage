using System.Linq;
using Core.Events.GameEvents.TimeEvents;
using UnityEngine;

namespace Core.Events.Pools {

    public class TimeEventPool : BasePool<BaseTimeEvent> {
        
        public override void InitPool() {
            _events =  Resources.LoadAll<BaseTimeEvent>("Events/Physical").ToList();
        }
    }

}
using Core.Events.Types;
using UnityEngine;

namespace Core.Events.GameEvents.PhysEvents {

    public abstract class BasePhysicalEvent : BaseGameEvent {

        [field: SerializeField]
        public PhysEventType type { get; protected set; }

        [field: SerializeField]
        public Sprite mapObjectSprite { get; private set; }

    }

}
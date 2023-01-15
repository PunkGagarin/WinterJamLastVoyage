using Core.Events.Types;
using UnityEngine;

namespace Core.Events.GameEvents.TimeEvents {

    public abstract class BaseTimeEvent : BaseGameEvent {

        [field: SerializeField]
        public TimeEventType type { get; protected set; }

        [field: SerializeField]
        public Sprite mapObjectSprite { get; private set; }

    }

}
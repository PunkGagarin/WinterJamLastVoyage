using Core.Events.Types;
using events;
using UnityEngine;

namespace Core.Events.GameEvents {

    
    public abstract class BaseGameEvent : ScriptableObject, IGameEvent {

        [field: SerializeField]
        public BaseEventType baseEventType { get; private set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string gameEventText { get; private set; }

        [field: SerializeField]
        public string acceptButtonText { get; private set; }

        [field: SerializeField]
        public string rejectButtonText { get; private set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string acceptedText { get; private set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string rejectedText { get; private set; }

        // [SerializeField]
        //todo: for future random weight pickup
        // private int _weight;

        public abstract void Apply();

        public abstract void Reject();
    }

}
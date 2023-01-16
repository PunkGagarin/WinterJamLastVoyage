using Core.Events.Types;
using UnityEngine;

namespace Core.Events.GameEvents {

    
    public abstract class BaseGameEvent : ScriptableObject, IGameEvent {

        [field: SerializeField]
        public BaseEventType baseEventType { get; private set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string gameEventText { get; protected set; }

        [field: SerializeField]
        public string acceptButtonText { get; protected set; }

        [field: SerializeField]
        public string rejectButtonText { get; protected set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string acceptedText { get; protected set; }

        [field: SerializeField]
        [field:TextAreaAttribute(5,20)]
        public string rejectedText { get; protected set; }

        // [SerializeField]
        //todo: for future random weight pickup
        // private int _weight;

        public abstract void Apply();

        public abstract void Reject();
    }

}
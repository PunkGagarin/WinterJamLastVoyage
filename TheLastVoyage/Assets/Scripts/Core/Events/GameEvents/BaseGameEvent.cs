using System.Collections.Generic;
using GameSession.Events;
using UnityEngine;

namespace events {

    public abstract class BaseGameEvent : MonoBehaviour {

        [field: SerializeField]
        public string gameEventText { get; }

        [field: SerializeField]
        public string acceptButtonText { get; set; }
        
        [field: SerializeField]
        public string rejectButtonText { get; set; }

        [field: SerializeField]
        public string acceptedText { get; }

        [field: SerializeField]
        public string rejectedText { get; }

        // [SerializeField]
        //todo: for future random weight pickup
        private int _weight;

        public abstract void Apply();

        public abstract void Reject();
    }

}
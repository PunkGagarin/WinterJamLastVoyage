using System.Collections.Generic;
using GameSession.Events;
using UnityEngine;

namespace events {

    public class BaseGameEvent : MonoBehaviour {

        [SerializeField]
        protected string _gameEventText;

        [SerializeField]
        protected List<EventButton> _eventButtons;

        public virtual void Apply(EventController eventController) {
            //todo: implement all events
        }
    }

}
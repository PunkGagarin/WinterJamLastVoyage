using System.Collections.Generic;
using events;
using TMPro;
using UnityEngine;

namespace Events {

    public class EventView : MonoBehaviour {

        [SerializeField]
        private TextMeshProUGUI _eventText;

        [SerializeField]
        private Transform _buttonsParent;

        private List<EventButton> _eventButtons;
        
        
    }

}

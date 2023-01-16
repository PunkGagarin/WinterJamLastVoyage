using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/InfectionOutbreak", fileName = "InfectionOutbreak")]
    public class InfectionOutbreakEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _acceptedHungerDrop = 10;
        
        [SerializeField]
        private int _timeCost = 15;

        [Header("Reject")]
        [SerializeField]
        private int _rejectedHungerDrop = 15;
        
        [SerializeField]
        private int _rejectedMoraleDrop = 15;

        private void Awake() {
            type = TimeEventType.InfectionOutbreak;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseHungerIndicator(_acceptedHungerDrop);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseHungerIndicator(_rejectedHungerDrop);
            _shipCharacteristics.DecreaseMoraleIndicator(_rejectedMoraleDrop);
        }
    }

}
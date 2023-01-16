using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/Drought", fileName = "Drought")]
    public class DroughtEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleBonus = 5;
        
        [SerializeField]
        private int _timeCost = 15;
        
        [SerializeField]
        private int _acceptedHungerDrop = 5;

        [Header("Reject")]
        [SerializeField]
        private int _rejectedMoraleDrop = 10;
        
        [SerializeField]
        private int _rejectedHungerDrop = 5;

        private void Awake() {
            type = TimeEventType.Drought;
        }


        public override void Apply() {
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _shipCharacteristics.DecreaseHungerIndicator(_acceptedHungerDrop);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_rejectedMoraleDrop);
            _shipCharacteristics.DecreaseHungerIndicator(_rejectedHungerDrop);
        }
    }

}
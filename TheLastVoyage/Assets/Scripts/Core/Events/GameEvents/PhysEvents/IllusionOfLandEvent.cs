using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/IllusionOfLand", fileName = "IllusionOfLand")]
    public class IllusionOfLandEvent : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleDrop = 10;
        
        [SerializeField]
        private int _hungerDrop = 10;
        
        [SerializeField]
        private int _timeCost = 10;

        [Header("Reject")]
        [SerializeField]
        private int _rejectMoraleDrop = 5;

        private void Awake() {
            type = PhysEventType.IllusionOfLand;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseMoraleIndicator(_moraleDrop);
            _shipCharacteristics.DecreaseHungerIndicator(_hungerDrop);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_rejectMoraleDrop);
        }
    }

}
using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/Pirates", fileName = "Pirates")]
    public class PiratesEvent : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _acceptDamage = 20;
        
        [SerializeField]
        private int _acceptTimeCost = 15;
        
        [SerializeField]
        private int _acceptMoraleDrop = 10;

        [Header("Reject")]
        [SerializeField]
        private int _rejectTimeCost = 5;
        
        [SerializeField]
        private int _rejectMoraleDrop = 5;
        
        [SerializeField]
        private int _rejectHungerDrop = 5;

        private void Awake() {
            type = PhysEventType.Pirates;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseHealthIndicator(_acceptDamage);
            _shipCharacteristics.DecreaseMoraleIndicator(_acceptMoraleDrop);
            _gameTimer.DecreaseTime(_acceptTimeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseHungerIndicator(_rejectHungerDrop);
            _shipCharacteristics.DecreaseMoraleIndicator(_rejectMoraleDrop);
            _gameTimer.DecreaseTime(_rejectTimeCost);
        }
    }

}
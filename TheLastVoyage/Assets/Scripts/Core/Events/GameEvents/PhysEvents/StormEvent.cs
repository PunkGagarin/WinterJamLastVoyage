using Core.Control;
using GameSession;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/Mutiny", fileName = "Mutiny")]
    public class StormEvent : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleBonus;
        
        [SerializeField]
        private int _hungerDrop;
        
        [SerializeField]
        private int _timeCost;

        [Header("Reject")]
        [SerializeField]
        private int _rejectHungerDrop;
        
        [SerializeField]
        private int _damage;


        public override void Apply() {
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _shipCharacteristics.DecreaseHungerIndicator(_hungerDrop);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseHungerIndicator(_rejectHungerDrop);
            _shipCharacteristics.DecreaseHealthIndicator(_damage);
        }
    }

}
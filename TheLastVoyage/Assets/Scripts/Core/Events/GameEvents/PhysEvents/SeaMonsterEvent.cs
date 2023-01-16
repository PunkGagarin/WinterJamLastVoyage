using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/SeaMonster", fileName = "SeaMonster")]
    public class SeaMonsterEvent : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _damage = 10;
        
        [SerializeField]
        private int _hungerBonus = 30;
        
        [SerializeField]
        private int _timeCost = 5;
        
        [SerializeField]
        private int _moraleBonus = 5;

        private void Awake() {
            type = PhysEventType.SeaMonster;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseHealthIndicator(_damage);
            _shipCharacteristics.IncreaseHungerIndicator(_hungerBonus);
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
        }
    }

}
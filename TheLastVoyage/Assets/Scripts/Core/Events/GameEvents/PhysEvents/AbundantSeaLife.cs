using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/AbundantSeaLife", fileName = "AbundantSeaLife")]
    public class AbundantSeaLife : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _hungerBonusMin = 10;

        [SerializeField]
        private int _hungerBonusMax = 35;

        [SerializeField]
        private int _timeLost = 15;

        [SerializeField]
        private int _moraleBonus = 10;

        [Header("Reject")]
        [SerializeField]
        private int _moraleDrop = 10;

        private void Awake() {
            type = PhysEventType.AbundantSeaLife;
        }

        public override void Apply() {
            _shipCharacteristics.IncreaseHungerIndicator(Random.Range(_hungerBonusMin, _hungerBonusMax));
            _gameTimer.DecreaseTime(_timeLost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_moraleDrop);
        }
    }

}
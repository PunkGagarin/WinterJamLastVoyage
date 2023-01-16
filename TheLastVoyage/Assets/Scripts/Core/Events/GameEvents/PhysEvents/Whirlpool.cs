using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/Whirlpool", fileName = "Whirlpool")]
    public class Whirlpool : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _damageMin = 1;

        [SerializeField]
        private int _damageMax = 15;

        [SerializeField]
        private int _timeBonusMin = -5;

        [SerializeField]
        private int _timeBonusMax = 25;

        [Header("Reject")]
        [SerializeField]
        private int _timeLost = 15;

        private void Awake() {
            type = PhysEventType.Whirlpool;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseHealthIndicator(Random.Range(_damageMin, _damageMax));
            int time = Random.Range(_timeBonusMin, _timeBonusMax);
            if (time >= 0) {
                _gameTimer.IncreaseTime(time);
            } else {
                _gameTimer.DecreaseTime(time);
            }
        }

        public override void Reject() {
            _gameTimer.DecreaseTime(_timeLost);
        }
    }

}
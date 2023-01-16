using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/LuckyFishCatch", fileName = "LuckyFishCatch")]
    public class LuckyFishCatchEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _damage = 5;

        [SerializeField]
        private int _timeCost = 5;

        [SerializeField]
        private int _hungerBonus = 40;

        [SerializeField]
        private int _moraleBonus = 10;

        [Header("Reject")]
        [SerializeField]
        private int _moralesDrop = 10;

        private void Awake() {
            type = TimeEventType.LuckyFishCatch;
        }


        public override void Apply() {
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _shipCharacteristics.IncreaseHungerIndicator(_hungerBonus);
            _shipCharacteristics.DecreaseHealthIndicator(_damage);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_moralesDrop);
        }
    }

}
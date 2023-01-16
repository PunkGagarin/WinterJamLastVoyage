using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/FireOnBoard", fileName = "FireOnBoard")]
    public class FireOnBoardEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleBonus = 15;

        [SerializeField]
        private int _timeCost = 15;

        [Header("Reject")]
        [SerializeField]
        private int _rejectedMoraleDrop = 10;

        private void Awake() {
            type = TimeEventType.FireOnBoard;
        }

        public override void Apply() {
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_rejectedMoraleDrop);
        }
    }

}
using System;
using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.PhysEvents {

    [CreateAssetMenu(menuName = "GameEvent/Physical/Shipwreck", fileName = "Shipwreck")]
    public class ShipWreckEvent : BasePhysicalEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _hungerBonus;

        [SerializeField]
        private int _timeCost;

        [Header("Reject")]
        [SerializeField]
        private int _moraleDecrease;

        private void Awake() {
            type = PhysEventType.Shipwreck;
        }


        public override void Apply() {
            _shipCharacteristics.DecreaseHungerIndicator(_hungerBonus);
            _gameTimer.DecreaseTime(_timeCost);
        }

        public override void Reject() {
            _shipCharacteristics.DecreaseMoraleIndicator(_moraleDecrease);
        }
    }

}
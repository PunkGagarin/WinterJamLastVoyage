using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/FoodShortage", fileName = "FoodShortage")]
    public class FoodShortageEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleBonus = 10;

        [SerializeField]
        private int _timeCost = 15;

        [Header("Reject")]
        [SerializeField]
        private int _rejectedMoraleDrop = 20;

        private void Awake() {
            type = TimeEventType.FoodShortage;
            gameEventText =
                "Your ship is running low on food supplies and the crew is starting to feel the effects of hunger. " +
                "You must decide how to handle the situation, as the food shortage can affect the crew's health, morale, and your journey.";
            acceptedText = "You decide to take immediate action to find more food. " +
                           "You order the crew to ration the food supplies, and you start searching for food sources, " +
                           "such as nearby islands or passing ships. You also order the crew to hunt for food, fish and gather fruits and nuts if possible. " +
                           "Your decision takes time and resources, but it prevents the crew from starving and keeps the crew healthy.";
            rejectedText = "You decide to ignore the problem and hope that it will go away on its own. " +
                           "But the food supplies continue to decrease, and the crew's hunger level increases. " +
                           "You must now deal with the consequences of your inaction, and try to find food, but it will take more time and resources, " +
                           "and the morale of the crew is affected. " +
                           "Additionally, the ship's navigation and safety are compromised.";
            acceptButtonText = "Search";
            acceptButtonText = "Ignore";
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
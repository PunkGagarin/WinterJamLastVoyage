using System;
using Core.Events.UI;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Control {
    public class WaterSpawner : MonoBehaviour {

        [SerializeField] 
        private GameObject _waterPrefab;
        
        [SerializeField] 
        private GameObject _waterEventPrefab;

        [SerializeField] 
        private Transform _waterSpawnPoint;

        [SerializeField] 
        private ShipController _shipController;

        [SerializeField] 
        private WaterController _firstWaterController;
        
        [Inject]
        private EventView _eventView;

       [Inject]
        private DiContainer _diContainer;

        private void Start() {
            _firstWaterController.shipController = _shipController;
            _firstWaterController.OnEnterDestroy.AddListener(() => Destroy(_firstWaterController.gameObject));
            
            SpawnWaterTile();
        }

        private void SpawnWaterTile() {
            
            var waterPrefab = _waterEventPrefab;
            
            var water = Instantiate(waterPrefab);
            water.transform.position = _waterSpawnPoint.position;
            var waterController = water.GetComponent<WaterController>();
            waterController.OnEnter.AddListener(SpawnWaterTile);
            waterController.OnEnterDestroy.AddListener(() => Destroy(water.gameObject));
            waterController.shipController = _shipController;
            
            if (Random.Range(0,100) > 85) {
               var eventTrigger = _diContainer.InstantiateComponent<GameEventTrigger>(waterController.GameEventTriggerGameobject);
               eventTrigger.SetActive(true);
            }
        }
    }
}
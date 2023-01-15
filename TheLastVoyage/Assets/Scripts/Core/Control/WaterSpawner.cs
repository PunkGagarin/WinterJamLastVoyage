using System;
using UnityEngine;

namespace Core.Control {
    public class WaterSpawner : MonoBehaviour {

        [SerializeField] 
        private GameObject _waterPrefab;

        [SerializeField] 
        private Transform _waterSpawnPoint;

        [SerializeField] 
        private ShipController _shipController;

        [SerializeField] 
        private WaterController _firstWaterController;

        private void Start() {
            _firstWaterController.shipController = _shipController;
            _firstWaterController.OnEnterDestroy.AddListener(() => Destroy(_firstWaterController.gameObject));
            
            SpawnWaterTile();
        }

        private void SpawnWaterTile() {
            var water = Instantiate(_waterPrefab);
            water.transform.position = _waterSpawnPoint.position;
            var waterController = water.GetComponent<WaterController>();
            waterController.OnEnter.AddListener(SpawnWaterTile);
            waterController.OnEnterDestroy.AddListener(() => Destroy(water.gameObject));
            waterController.shipController = _shipController;
            
            Destroy(water.gameObject, 30f);
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Control {
    public class ObstaclesController : MonoBehaviour {

        [SerializeField] 
        private int _chanceSpawn = 70;
        
        [SerializeField] 
        private List<Transform> _obstacleGeneratePoints;
        
        [SerializeField] 
        private List<Sprite> _obstacleSprites;
        
        [SerializeField]
        private GameObject _obstaclePrefab;

        private void Start() {
            Generate();
        }

        private void Generate() {
            foreach (var point in _obstacleGeneratePoints) {
                if (Random.Range(0, 100) < _chanceSpawn) {
                    var obstacle = Instantiate(_obstaclePrefab, point, true);
                    obstacle.transform.position = point.position;
                    obstacle.GetComponent<SpriteRenderer>().sprite =
                        _obstacleSprites[Random.Range(0, _obstacleSprites.Count)];
                }
            }
        }
    }
}
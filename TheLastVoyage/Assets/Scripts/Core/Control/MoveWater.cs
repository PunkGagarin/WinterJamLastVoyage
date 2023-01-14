using UnityEngine;

namespace Core.Control {
    public class MoveWater : MonoBehaviour {
        private void Update() {
            transform.Translate(Vector3.down * 0.005f);
        }
    }
}
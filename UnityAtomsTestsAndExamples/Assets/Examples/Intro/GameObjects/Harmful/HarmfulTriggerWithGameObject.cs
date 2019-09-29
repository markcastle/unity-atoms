using UnityEngine;

namespace UnityAtoms.Examples
{
    public class HarmfulTriggerWithGameObject : MonoBehaviour
    {
        [SerializeField]
        private Collider2DGameObjectEvent _harmfullEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _harmfullEvent.Raise(other, gameObject);
        }
    }
}

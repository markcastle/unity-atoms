using UnityEngine;

namespace UnityAtoms.Examples
{
    public class ScoreTrigger : MonoBehaviour
    {
        [SerializeField]
        private Collider2DGameObjectEvent _collider2DGameObjectEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _collider2DGameObjectEvent.Raise(other, gameObject);
        }
    }
}

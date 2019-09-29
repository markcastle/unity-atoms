using UnityEngine;

namespace UnityAtoms
{
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Collider2DGameObject", fileName = "Collider2DGameObjectEvent")]
    public sealed class Collider2DGameObjectEvent : AtomEvent<Collider2D, GameObject> { }
}

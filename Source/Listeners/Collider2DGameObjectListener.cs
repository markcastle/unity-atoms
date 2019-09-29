using UnityEngine;

namespace UnityAtoms
{
    [AddComponentMenu("Unity Atoms/Listeners/Collider2DGameObject")]
    public sealed class Collider2DGameObjectListener : AtomListener<
        Collider2D,
        GameObject,
        Collider2DGameObjectAction,
        Collider2DGameObjectEvent,
        Collider2DGameObjectUnityEvent>
    { }
}

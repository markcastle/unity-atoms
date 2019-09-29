using System;
using UnityEngine.Events;
using UnityEngine;

namespace UnityAtoms
{
    [Serializable]
    public sealed class Collider2DGameObjectUnityEvent : UnityEvent<Collider2D, GameObject> { }
}

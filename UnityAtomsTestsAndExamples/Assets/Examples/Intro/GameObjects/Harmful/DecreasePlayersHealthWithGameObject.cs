using UnityEngine;
using UnityAtoms.Tags;
using UnityEngine.Serialization;

namespace UnityAtoms.Examples
{
    [CreateAssetMenu(menuName = "Unity Atoms/Examples/Intro/Decrease Players Health (With GameObject)")]
    public sealed class DecreasePlayersHealthWithGameObject : Collider2DGameObjectAction
    {
        [FormerlySerializedAs("TagPlayer")]
        [SerializeField]
        private StringConstant _tagPlayer = null;

        public override void Do(Collider2D collider, GameObject go)
        {
           //  Debug.Log($"go.name={go.name}");

            if (collider.gameObject.HasTag(_tagPlayer))
            {
                collider.GetComponent<PlayerHealth>().Health.Value -= 5;
            }
        }
    }
}

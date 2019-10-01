using UnityEngine;
using UnityAtoms.Tags;
using UnityEngine.Serialization;

namespace UnityAtoms.Examples
{
    [CreateAssetMenu(menuName = "Unity Atoms/Examples/Intro/Increase Players Score (With GameObject)")]
    public sealed class IncreasePlayersScoreWithGameObject : Collider2DGameObjectAction
    {
        [FormerlySerializedAs("TagPlayer")]
        [SerializeField]
        private StringConstant _tagPlayer = null;

        [SerializeField]
        private IntVariable score;

        public override void Do(Collider2D collider, GameObject go)
        {
            Debug.Log($"go.name={go.name}");

            if (collider.gameObject.HasTag(_tagPlayer))
            {
                score.Value++;
                Debug.Log($"Score: { score.Value}");
            }
        }
    }
}

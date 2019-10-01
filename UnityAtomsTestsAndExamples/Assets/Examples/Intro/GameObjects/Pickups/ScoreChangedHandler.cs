using UnityEngine;
using UnityEngine.UI;

namespace UnityAtoms.Examples
{
    [AddComponentMenu("Unity Atoms/Examples/Score Changed Handler")]
    public class ScoreChangedHandler : MonoBehaviour
    {
        public void ScoreChanged(int score)
        {
            Debug.Log($"New Score: {score}");
            GetComponent<Text>().text = score.ToString();
        }
    }
}

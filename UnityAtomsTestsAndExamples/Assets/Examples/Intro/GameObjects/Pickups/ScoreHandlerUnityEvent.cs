using UnityEngine;

public class ScoreHandlerUnityEvent : MonoBehaviour
{

    public void HandleUnityEvent(Collider2D collider, GameObject sourceGameObject)
    {
        // Debug.Log($"collider.name={collider.name} go.name={sourceGameObject.name}");

        /// Instantiate a new clone of our object
        var clone = Instantiate(sourceGameObject, new Vector2(Random.Range(-7, 7), Random.Range(-4, 4)), Quaternion.identity);
        clone.name = clone.name.Replace("(Clone)", ""); //  Need to rename it otherwise the name grows with "(Clone)(Clone).... " etc.

        // Destroy self
        Destroy(sourceGameObject.transform.root.gameObject);

    }


}

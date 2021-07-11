using UnityEngine;

public class Cheat : MonoBehaviour
{
    [ContextMenu("Something")]
    private void ShowPoolerName()
    {
        Debug.Log(ObjectPooler.instance.name);
    }

    [ContextMenu("Add New Game Object To the pooler")]
    private void AddGameObjectUnderPooler()
    {
        GameObject newGO = new GameObject();
        newGO.transform.parent = ObjectPooler.instance.transform;
    }
}
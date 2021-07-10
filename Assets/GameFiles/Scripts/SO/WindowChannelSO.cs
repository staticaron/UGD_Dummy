using UnityEngine;

[CreateAssetMenu(fileName = "WIndowChannelSO", menuName = "UGD_Dummy/WIndowChannelSO", order = 0)]
public class WindowChannelSO : ScriptableObject
{
    public delegate void ShowGameOverUI();
    public event ShowGameOverUI EShowGameOverUI;

    public void RaiseShowGameOverUIEvent()
    {
        if (EShowGameOverUI == null)
        {
            Debug.LogWarning("Show Game Over UI event was raised but no one was listening to it");
        }
        else
        {
            EShowGameOverUI();
        }
    }
}
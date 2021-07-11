using UnityEngine;

[CreateAssetMenu(fileName = "WIndowChannelSO", menuName = "UGD_Dummy/WIndowChannelSO", order = 0)]
public class WindowChannelSO : ScriptableObject
{
    public delegate void ShowGameOverUI();
    public event ShowGameOverUI EShowGameOverUI;

    public delegate void WinUI();
    public event WinUI EShowWinUI;

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

    public void RaiseWinUIEvent()
    {
        if (EShowWinUI != null)
        {
            EShowWinUI();
        }
        else
        {
            Debug.LogWarning("Win UI event was called but no was listening to it");
        }
    }
}
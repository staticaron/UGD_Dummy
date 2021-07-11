using UnityEngine;

[CreateAssetMenu(fileName = "ScoreChannelSO", menuName = "UGD_Dummy/ScoreChannelSO", order = 0)]
public class ScoreChannelSO : ScriptableObject
{
    public delegate void UpdateScore(int delta);
    public event UpdateScore EUpdateScore;

    public delegate void UpdateUI(int newScore);
    public event UpdateUI EUpdateUI;

    public void RaiseUdpateScoreEvent(int delta)
    {
        if (EUpdateScore != null)
        {
            EUpdateScore(delta);
        }
        else
        {
            Debug.LogWarning("Update Score was raised but no one was listening to it");
        }
    }

    public void RaiseUpdateUIEvent(int newScore)
    {
        if (EUpdateUI != null)
        {
            EUpdateUI(newScore);
        }
        else
        {
            Debug.LogWarning("Update Score UI was raised but no one was listening to it");
        }
    }
}
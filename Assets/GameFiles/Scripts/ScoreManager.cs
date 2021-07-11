using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Properties
    public static ScoreManager instance;

    private int currentScore;
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    [SerializeField] ScoreChannelSO scoreChannelSO;
    [SerializeField] WindowChannelSO windowChannelSO;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void OnEnable()
    {
        scoreChannelSO.EUpdateScore += UpdateScore;
        windowChannelSO.EShowGameOverUI += () => { PlayerPrefs.SetInt("Max", CurrentScore > PlayerPrefs.GetInt("Max") ? CurrentScore : PlayerPrefs.GetInt("Max")); CurrentScore = 0; };
        windowChannelSO.EShowWinUI += () => { PlayerPrefs.SetInt("Max", CurrentScore > PlayerPrefs.GetInt("Max") ? CurrentScore : PlayerPrefs.GetInt("Max")); CurrentScore = 0; };
    }

    private void OnDisable()
    {
        scoreChannelSO.EUpdateScore -= UpdateScore;
    }
    #endregion

    #region Private Functions
    private void UpdateScore(int delta)
    {
        CurrentScore += delta;
        scoreChannelSO.RaiseUpdateUIEvent(CurrentScore);
    }
    #endregion

    #region Public Functions

    #endregion
}

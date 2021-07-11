using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMananger : MonoBehaviour
{
    #region Properties
    private const string MainSceneName = "Game";

    [SerializeField, Space] TMP_Text scoreTextMainMenu;
    [SerializeField] TMP_Text scoreTextGame;
    [SerializeField] TMP_Text scoreTextGameOver;
    [SerializeField] TMP_Text scoreTextWin;

    [SerializeField, Space] ScoreChannelSO scoreChannelSO;
    #endregion

    #region MonobehavioursFunctions
    private void Awake()
    {
        scoreTextMainMenu.text = PlayerPrefs.GetInt("Max").ToString();
    }

    private void OnEnable()
    {
        scoreChannelSO.EUpdateUI += UpdateScoreUI;
    }

    private void OnDisable()
    {
        scoreChannelSO.EUpdateUI -= UpdateScoreUI;
    }
    #endregion

    #region Private Functions
    private void UpdateScoreUI(int newScore)
    {
        scoreTextGame.text = newScore.ToString();
        scoreTextGameOver.text = newScore.ToString();
        scoreTextWin.text = newScore.ToString();
    }
    #endregion

    #region Public Functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}

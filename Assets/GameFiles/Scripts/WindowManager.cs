using UnityEngine;

public class WindowManager : MonoBehaviour
{
    #region Properties
    [SerializeField] WindowChannelSO windowChannelSO;

    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject winWindow;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        windowChannelSO.EShowGameOverUI += ShowGameOverWindow;
        windowChannelSO.EShowWinUI += ShowWinWindow;
    }

    private void OnDisable()
    {
        windowChannelSO.EShowGameOverUI -= ShowGameOverWindow;
        windowChannelSO.EShowWinUI -= ShowWinWindow;
    }
    #endregion

    #region Private Functions
    private void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    private void ShowWinWindow()
    {
        winWindow.SetActive(true);
    }
    #endregion

    #region Public Functions

    #endregion
}

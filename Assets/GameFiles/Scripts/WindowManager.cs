using UnityEngine;

public class WindowManager : MonoBehaviour
{
    #region Properties
    [SerializeField] WindowChannelSO windowChannelSO;

    [SerializeField] GameObject gameOverWindow;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        windowChannelSO.EShowGameOverUI += ShowGameOverWindow;
    }

    private void OnDisable()
    {
        windowChannelSO.EShowGameOverUI -= ShowGameOverWindow;
    }
    #endregion

    #region Private Functions
    private void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
    #endregion

    #region Public Functions

    #endregion
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMananger : MonoBehaviour
{
    #region Properties
    private const string MainSceneName = "Game";
    #endregion

    #region MonobehavioursFunctions

    #endregion

    #region Private Functions

    #endregion

    #region Public Functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}

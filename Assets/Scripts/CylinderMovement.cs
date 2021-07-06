using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    #region Properties
    [SerializeField] float rotateSpeed = 10.0f;
    #endregion

    #region MonobehavioursFunctions
    private void Update()
    {
        transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
    }
    #endregion

    #region Private Functions

    #endregion

    #region Public Functions

    #endregion
}

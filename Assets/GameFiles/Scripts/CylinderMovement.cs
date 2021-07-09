using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    #region Properties
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] float pushDistance = 0f;

    [SerializeField, Space] CylinderPushChannelSO cylinderPushChannelSO;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        cylinderPushChannelSO.EPushCylinder += PushCylinder;
    }

    private void OnDisable()
    {
        cylinderPushChannelSO.EPushCylinder -= PushCylinder;
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
    }
    #endregion

    #region Private Functions
    private void PushCylinder(int steps)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + steps * pushDistance, transform.position.z);
    }
    #endregion

    #region Public Functions

    #endregion
}

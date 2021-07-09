using UnityEngine;

[CreateAssetMenu(fileName = "CylinderPushChannelSO", menuName = "UGD_Dummy/CylinderPushChannelSO", order = 0)]
public class CylinderPushChannelSO : ScriptableObject
{
    public delegate void PushCylinder(int steps);
    public event PushCylinder EPushCylinder;

    public void RaiseEvent(int steps)
    {
        if (EPushCylinder != null)
        {
            EPushCylinder(steps);
        }
        else
        {
            Debug.LogWarning("PushCylinder was raised but no was listening to it");
        }
    }
}
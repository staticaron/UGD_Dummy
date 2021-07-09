using UnityEngine;

[CreateAssetMenu(fileName = "AddLayerChannelSO", menuName = "UGD_Dummy/AddLayerChannelSO", order = 0)]
public class AddLayerChannelSO : ScriptableObject
{
    public delegate void AddPieceLayerAtBottom();
    public event AddPieceLayerAtBottom EAddPieceLayerAtBottom;

    public void RaiseEvent()
    {
        if (EAddPieceLayerAtBottom != null)
        {
            EAddPieceLayerAtBottom();
        }
        else
        {
            Debug.LogWarning("AddPieceLayerAtBottom was raised but no one was listening to it");
        }
    }
}
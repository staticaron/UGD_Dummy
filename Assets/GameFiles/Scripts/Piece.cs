using UnityEngine;

public class Piece : MonoBehaviour, IInteractable
{
    #region Properties
    [SerializeField] PieceType thisPieceType = PieceType.NORMAL;
    [SerializeField] GameObject PieceParticleGO;

    [SerializeField, Space] ParticleChannelSO particleChannelSO;
    #endregion

    #region MonobehavioursFunctions

    #endregion

    #region Private Functions

    public void TouchAction()
    {
        if (thisPieceType == PieceType.NORMAL)
        {
            Debug.Log("Ball touched the normal piece");
            particleChannelSO.RaiseEvent(ParticleType.NORMAL, transform);
            Destroy(gameObject);
        }
        else if (thisPieceType == PieceType.DANGER)
        {
            Debug.Log("Ball touched the danger piece");
            particleChannelSO.RaiseEvent(ParticleType.DANGER, transform);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public Functions

    #endregion
}

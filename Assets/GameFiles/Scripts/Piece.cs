using UnityEngine;

public class Piece : MonoBehaviour, IInteractable
{
    #region Properties
    [SerializeField] PieceType thisPieceType = PieceType.NORMAL;
    [SerializeField] GameObject PieceParticleGO;

    [SerializeField, Space] ParticleChannelSO particleChannelSO;

    private PieceSpawner parentSpawner = null;
    #endregion

    #region MonobehavioursFunctions

    #endregion

    #region Private Functions

    #endregion

    #region Public Functions

    public void TouchAction()
    {
        if (thisPieceType == PieceType.NORMAL)
        {
            particleChannelSO.RaiseEvent(ParticleType.NORMAL, transform);
            parentSpawner.NumberOfNormalPiece -= 1;
            this.gameObject.SetActive(false);
        }
        else if (thisPieceType == PieceType.DANGER)
        {
            particleChannelSO.RaiseEvent(ParticleType.DANGER, transform);
            this.gameObject.SetActive(false);
        }
    }

    public void SetParentSpawner(PieceSpawner parentSpawner)
    {
        this.parentSpawner = parentSpawner;
    }


    #endregion
}

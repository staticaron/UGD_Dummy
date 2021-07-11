using UnityEngine;

public class Piece : MonoBehaviour, IInteractable
{
    #region Properties
    [SerializeField] PieceType thisPieceType = PieceType.NORMAL_PURPLE;
    [SerializeField] GameObject PieceParticleGO;

    [SerializeField, Space] ParticleChannelSO particleChannelSO;
    [SerializeField] WindowChannelSO windowChannelSO;
    [SerializeField] ScoreChannelSO scoreChannelSO;

    private PieceSpawner parentSpawner = null;
    #endregion

    #region MonobehavioursFunctions

    #endregion

    #region Private Functions

    #endregion

    #region Public Functions

    public void TouchAction()
    {
        if (thisPieceType == PieceType.NORMAL_PURPLE)
        {
            particleChannelSO.RaiseEvent(ParticleType.NORMAL_PURPLE, transform);
            parentSpawner.NumberOfNormalPiece -= 1;
            scoreChannelSO.RaiseUdpateScoreEvent(1);
            this.gameObject.SetActive(false);
        }
        else if (thisPieceType == PieceType.NORMAL_ORANGE)
        {
            particleChannelSO.RaiseEvent(ParticleType.NORMAL_ORANGE, transform);
            parentSpawner.NumberOfNormalPiece -= 1;
            scoreChannelSO.RaiseUdpateScoreEvent(1);
            this.gameObject.SetActive(false);
        }
        else if (thisPieceType == PieceType.NORMAL_RED)
        {
            particleChannelSO.RaiseEvent(ParticleType.NORMAL_RED, transform);
            parentSpawner.NumberOfNormalPiece -= 1;
            scoreChannelSO.RaiseUdpateScoreEvent(1);
            this.gameObject.SetActive(false);
        }
        else if (thisPieceType == PieceType.DANGER)
        {
            //Spawn the particle effect at the position
            particleChannelSO.RaiseEvent(ParticleType.DANGER, transform);

            windowChannelSO.RaiseShowGameOverUIEvent();

            //TODO : Stop the rotation of the main cylinder

            //Disable the gameObject to be used by the object pooler
            this.gameObject.SetActive(false);
        }
    }

    public void SetParentSpawner(PieceSpawner parentSpawner)
    {
        this.parentSpawner = parentSpawner;
    }


    #endregion
}

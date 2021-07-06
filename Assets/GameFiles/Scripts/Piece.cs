using UnityEngine;

public class Piece : MonoBehaviour
{
    #region Properties
    private const string PlayerLayerName = "Player";

    [SerializeField] PieceType thisPieceType = PieceType.NORMAL;
    #endregion

    #region MonobehavioursFunctions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerLayerName))
        {
            if (thisPieceType == PieceType.NORMAL)
            {
                //TODO : Give Points
                //TODO : Destroy the piece
            }
            else if (thisPieceType == PieceType.DANGER)
            {
                //TODO : Destroy the ball
                //TODO : Destroy the piece
                //TODO : Restart the level
            }
        }
    }
    #endregion

    #region Private Functions

    #endregion

    #region Public Functions

    #endregion
}

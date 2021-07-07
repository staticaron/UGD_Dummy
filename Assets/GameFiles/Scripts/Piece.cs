using UnityEngine;

public class Piece : MonoBehaviour, IInteractable
{
    #region Properties
    [SerializeField] PieceType thisPieceType = PieceType.NORMAL;
    [SerializeField] GameObject PieceParticleGO;
    #endregion

    #region MonobehavioursFunctions

    #endregion

    #region Private Functions

    public void TouchAction()
    {
        if (thisPieceType == PieceType.NORMAL)
        {
            Debug.Log("Ball touched the normal piece");
            Instantiate(PieceParticleGO, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (thisPieceType == PieceType.DANGER)
        {
            Debug.Log("Ball touched the danger piece");
            Instantiate(PieceParticleGO, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public Functions

    #endregion
}

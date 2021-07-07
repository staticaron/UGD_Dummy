using UnityEngine;

public class Ball : MonoBehaviour
{
    #region  Properties
    private const string PieceTagName = "Piece";
    private const string MainCylinderTagName = "MainCylinder";
    #endregion

    #region  MonoBehaviourMethods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PieceTagName) || other.CompareTag(MainCylinderTagName))
        {
            //Execute the piece action on the other gameObject on ball touch 
            other.GetComponent<IInteractable>().TouchAction();
        }
    }
    #endregion

    #region  Private Methods

    #endregion

    #region  Public Methods

    #endregion
}
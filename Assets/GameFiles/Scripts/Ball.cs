using UnityEngine;

public class Ball : MonoBehaviour
{
    #region  Properties
    private const string PieceTagName = "Piece";
    private const string MainCylinderTagName = "MainCylinder";

    private bool hit = false;
    #endregion

    #region  MonoBehaviourMethods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PieceTagName) || other.CompareTag(MainCylinderTagName))
        {
            //If not hit already
            if (hit == false)
            {
                //Execute the piece action on the other gameObject on ball touch 
                other.GetComponent<IInteractable>().TouchAction();
                hit = true;
            }
        }
    }
    #endregion

    #region  Private Methods

    #endregion

    #region  Public Methods
    public void SetHit(bool newHitValue)
    {
        hit = newHitValue;
    }
    #endregion
}
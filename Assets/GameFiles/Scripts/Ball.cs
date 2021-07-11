using UnityEngine;

public class Ball : MonoBehaviour
{
    #region  Properties
    private const string PieceTagName = "Piece";
    private const string MainCylinderTagName = "MainCylinder";

    private bool hit = false;

    [SerializeField] WindowChannelSO windowChannelSO;
    [SerializeField] ParticleChannelSO particleChannelSO;
    #endregion

    #region  MonoBehaviourMethods
    private void OnEnable()
    {
        windowChannelSO.EShowGameOverUI += DestroyBall;
    }

    private void OnDisable()
    {
        windowChannelSO.EShowGameOverUI -= DestroyBall;
    }

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
    private void DestroyBall()
    {
        particleChannelSO.RaiseEvent(ParticleType.BALL, transform);
        gameObject.SetActive(false);
    }

    #endregion

    #region  Public Methods
    public void SetHit(bool newHitValue)
    {
        hit = newHitValue;
    }
    #endregion
}
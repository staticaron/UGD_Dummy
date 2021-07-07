using UnityEngine;

public class Launcer : MonoBehaviour
{
    #region Properties
    [SerializeField, Space] Transform ball;

    [SerializeField] AnimationCurve ballMovementCurve;
    [SerializeField] float ballSpeedModifier = 1;

    [SerializeField, Space] Transform rayPoint;
    [SerializeField] LayerMask rayMask;

    [SerializeField, Space] BallMoveState currentBallMoveState = BallMoveState.READY;

    [SerializeField] RaycastHit rayHitData;
    [SerializeField] Vector3 initialPos;
    [SerializeField] float slider = 0f;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        initialPos = ball.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchBall();
        }

        if (currentBallMoveState == BallMoveState.MOVING)
        {
            slider += Time.deltaTime * ballSpeedModifier;
            slider = Mathf.Clamp(slider, 0, 1);

            float yVal = ballMovementCurve.Evaluate(slider) * rayHitData.distance;

            ball.position = new Vector3(initialPos.x, initialPos.y - yVal, initialPos.z);

            if (slider == 1)
            {
                currentBallMoveState = BallMoveState.READY;
                slider = 0;
            }
        }
    }
    #endregion

    #region Private Functions
    private void LaunchBall()
    {
        Physics.Raycast(rayPoint.position, rayPoint.forward, out rayHitData, Mathf.Infinity, rayMask);

        currentBallMoveState = BallMoveState.MOVING;
    }
    #endregion

    #region Public Functions

    #endregion
}

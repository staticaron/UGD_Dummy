using UnityEngine;

public class Launcer : MonoBehaviour
{
    #region Properties
    [SerializeField, Space] Transform ballTransform;
    [SerializeField, Space] Ball ball;

    [SerializeField] AnimationCurve ballMovementCurve;
    [SerializeField] float ballSpeedModifier = 1;

    [SerializeField, Space] Transform rayPoint;
    [SerializeField] LayerMask rayMask;

    [SerializeField, Space] BallMoveState currentBallMoveState = BallMoveState.READY;

    [SerializeField] RaycastHit rayHitData;
    [SerializeField] Vector3 initialPos;
    [SerializeField, Range(0, 1)] float slider = 0f;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        initialPos = ballTransform.position;
        ball = ballTransform.GetComponent<Ball>();
    }

    void Update()
    {

#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
#endif
#if UNITY_ANDROID
        Touch t = Input.GetTouch(0);
        if (Input.touchCount > 0 && t.phase == TouchPhase.Began)
        {
            LaunchBall();
        }
#endif

        if (currentBallMoveState == BallMoveState.MOVING)
        {
            slider += Time.deltaTime * ballSpeedModifier;
            slider = Mathf.Clamp(slider, 0, 1);

            float yVal = ballMovementCurve.Evaluate(slider) * rayHitData.distance;

            ballTransform.position = new Vector3(initialPos.x, initialPos.y - yVal, initialPos.z);

            if (slider == 1)
            {
                currentBallMoveState = BallMoveState.READY;
                ball.SetHit(false);
                slider = 0;
            }
        }

        Debug.DrawLine(rayPoint.position, rayPoint.position + new Vector3(0, -rayHitData.distance, 0), Color.green);
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

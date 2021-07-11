using UnityEngine;

public class Launcher : MonoBehaviour
{
    #region Properties
    [SerializeField, Space] Transform ballTransform;
    [SerializeField, Space] Ball ball;

    [SerializeField] AnimationCurve ballMovementCurve;
    [SerializeField] float ballSpeedModifier = 1;

    [SerializeField, Space] Transform rayPoint;
    [SerializeField] LayerMask rayMask;

    [SerializeField, Space] BallMoveState currentBallMoveState = BallMoveState.STOP;

    [SerializeField] RaycastHit rayHitData;
    [SerializeField] Vector3 initialPos;
    [SerializeField, Range(0, 1)] float slider = 0f;

    [SerializeField] WindowChannelSO windowChannelSO;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        initialPos = ballTransform.position;
        ball = ballTransform.GetComponent<Ball>();
    }

    private void OnEnable()
    {
        windowChannelSO.EShowGameOverUI += DisableBallMovement;
        windowChannelSO.EShowWinUI += DisableBallMovement;
    }

    private void OnDisable()
    {
        windowChannelSO.EShowGameOverUI -= DisableBallMovement;
        windowChannelSO.EShowWinUI -= DisableBallMovement;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }

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
    }
    #endregion

    #region Private Functions
    private void LaunchBall()
    {
        Physics.Raycast(rayPoint.position, rayPoint.forward, out rayHitData, Mathf.Infinity, rayMask);

        if (currentBallMoveState == BallMoveState.READY) currentBallMoveState = BallMoveState.MOVING;
    }

    #endregion

    #region Public Functions
    public void EnableBallMovement()
    {
        currentBallMoveState = BallMoveState.READY;
    }

    public void DisableBallMovement()
    {
        currentBallMoveState = BallMoveState.STOP;
    }
    #endregion
}

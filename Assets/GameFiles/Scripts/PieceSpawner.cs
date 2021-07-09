using UnityEngine;
using System.Collections.Generic;

public class PieceSpawner : MonoBehaviour
{
    #region Properties
    [SerializeField] Transform spawnPointsHolder;

    [SerializeField, Space] Transform topLayerHolder;
    [SerializeField] Transform bottomLayerHolder;

    [SerializeField, Space] List<Transform> points;

    [SerializeField, Space] GameObject normalPiece;
    [SerializeField] GameObject dangerPiece;

    [SerializeField, Space] int normalPercentage;
    [SerializeField] int dangerPercentage;

    [SerializeField, Space] AddLayerChannelSO addLayerChannelSO;
    [SerializeField] CylinderPushChannelSO cylinderPushChannelSO;

    private List<GameObject> pieceOfThisLayer = new List<GameObject>();

    private ObjectPooler pooler = null;
    private StackSpawner parentStackSpawner;

    [SerializeField, Space]
    int numberOfNormalPiece = 0;

    public int NumberOfNormalPiece
    {
        get { return numberOfNormalPiece; }
        set { numberOfNormalPiece = value; CheckPieceCount(); }
    }

    #endregion

    #region MonobehavioursFunctions
    private void OnDisable()
    {
        //Disable all the unused pieces of this layer to be used by object pooler
        foreach (GameObject item in pieceOfThisLayer)
        {
            item.SetActive(false);
        }
    }
    #endregion

    #region Private Functions
    public void SpawnPieces()
    {
        if (pooler == null) pooler = ObjectPooler.instance;

        //Spawn the piece layer 
        foreach (Transform t in points)
        {
            //Get a random piece type to spawn
            PoolObjectType randomType = GetRandomPoolObjectType();

            numberOfNormalPiece = randomType == PoolObjectType.NORMAL ? numberOfNormalPiece + 1 : numberOfNormalPiece;

            //Spawn that random piece
            GameObject randomRequest = pooler.GetGameObjectFromPool(randomType);
            randomRequest.transform.position = new Vector3(t.position.x, topLayerHolder.position.y, t.position.z);
            randomRequest.transform.rotation = t.rotation;
            randomRequest.transform.parent = this.transform;
            randomRequest.GetComponent<Piece>().SetParentSpawner(this);
            randomRequest.SetActive(true);

            //Spawn the danger bottom piece
            GameObject dangerRequest = pooler.GetGameObjectFromPool(PoolObjectType.DANGER);
            dangerRequest.transform.position = new Vector3(t.position.x, bottomLayerHolder.position.y, t.position.z);
            dangerRequest.transform.rotation = t.rotation;
            dangerRequest.transform.parent = this.transform;
            dangerRequest.GetComponent<Piece>().SetParentSpawner(this);
            dangerRequest.SetActive(true);

            pieceOfThisLayer.Add(randomRequest);
            pieceOfThisLayer.Add(dangerRequest);
        }
    }

    private PoolObjectType GetRandomPoolObjectType()
    {
        int randInt = Random.Range(0, 100);

        if (randInt >= 0 && randInt < normalPercentage)
        {
            return PoolObjectType.NORMAL;
        }
        else if (randInt >= normalPercentage && randInt < normalPercentage + dangerPercentage)
        {
            return PoolObjectType.DANGER;
        }
        else
        {
            Debug.LogError("Error returning pool object, returning Normal Pool Object");
            return PoolObjectType.NORMAL;
        }
    }

    private void CheckPieceCount()
    {
        if (NumberOfNormalPiece <= 0)
        {
            gameObject.SetActive(false);
            addLayerChannelSO.RaiseEvent();
            cylinderPushChannelSO.RaiseEvent(1);
        }
    }

    #endregion

    #region Public Functions
    public void SetParentSpawner(StackSpawner parentStackSpawner)
    {
        this.parentStackSpawner = parentStackSpawner;
    }
    #endregion
}

using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    //Create a stack of piece layers of predefined height
    //Call the random piece placer on these piece layers

    #region Properties

    [SerializeField] int stackHeight = 5;           //Number of stack layers to be placed
    [SerializeField] GameObject pieceLayerGO;       //Actual Piece Layer Prefab
    [SerializeField] float distanceBetweenLayers;   //The distance between the piece layers

    [SerializeField] AddLayerChannelSO addLayerChannelSO;

    private Vector2 initialPosition;
    private ObjectPooler pooler;

    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        //References
        pooler = ObjectPooler.instance;

        initialPosition = transform.position;

        //Subscribe to events
        addLayerChannelSO.EAddPieceLayerAtBottom += () => AddPieceLayerAtIndex(stackHeight);

        //Create Stack when the game starts
        CreateStack(stackHeight);
    }

    private void OnDisable()
    {
        addLayerChannelSO.EAddPieceLayerAtBottom -= () => AddPieceLayerAtIndex(stackHeight);
    }

    #endregion

    #region Private Functions

    //Creates a stack of piece layers of predefined height
    private void CreateStack(int stackHeight)
    {
        for (int i = 0; i < stackHeight; i++)
        {
            AddPieceLayerAtIndex(i);
        }
    }

    #endregion

    #region Public Functions

    public void AddPieceLayerAtIndex(int index)
    {
        float yVal = initialPosition.y - distanceBetweenLayers * index;

        //Create the layer
        GameObject g = pooler.GetGameObjectFromPool(PoolObjectType.PIECELAYER);
        g.transform.parent = this.transform;
        g.transform.position = new Vector3(0, yVal, 0);
        g.GetComponent<PieceSpawner>().SetParentSpawner(this);
        g.SetActive(true);

        //Generate the random piece arrangement
        PieceSpawner spawner = g.GetComponent<PieceSpawner>();
        spawner.SpawnPieces();
    }

    [ContextMenu("Add Piece to the bottom")]
    public void AddPieceLayerAtIndex()
    {
        float yVal = initialPosition.y - distanceBetweenLayers * stackHeight;

        //Create the layer
        GameObject g = pooler.GetGameObjectFromPool(PoolObjectType.PIECELAYER);
        g.transform.parent = this.transform;
        g.transform.position = new Vector3(0, yVal, 0);
        g.GetComponent<PieceSpawner>().SetParentSpawner(this);
        g.SetActive(true);

        //Generate the random piece arrangement
        PieceSpawner spawner = g.GetComponent<PieceSpawner>();
        spawner.SpawnPieces();
    }

    #endregion
}

using UnityEngine;
using System;

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
        addLayerChannelSO.EAddPieceLayerAtBottom += AddPieceAtBottom;

        //Create Stack when the game starts
        CreateStack(stackHeight);
    }

    private void OnDisable()
    {
        addLayerChannelSO.EAddPieceLayerAtBottom -= AddPieceAtBottom;
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

    [ContextMenu("Holp")]
    public void AddPieceAtBottom()
    {
        AddPieceLayerAtIndex(stackHeight);
    }

    private void AddPieceLayerAtIndex(int index)
    {
        float yVal = initialPosition.y - distanceBetweenLayers * index;

        //Create the layer
        PreparePieceLayer(yVal);
    }

    private void PreparePieceLayer(float yVal)
    {
        GameObject g = pooler.GetGameObjectFromPool(PoolObjectType.PIECELAYER);
        g.transform.parent = transform;
        g.transform.position = new Vector3(0, yVal, 0);
        g.GetComponent<PieceSpawner>().SetParentSpawner(this);
        g.SetActive(true);

        //Generate the random piece arrangement
        PieceSpawner spawner = g.GetComponent<PieceSpawner>();
        spawner.SpawnPieces();
    }

    #endregion

    #region Public Functions

    #endregion
}

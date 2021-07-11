using UnityEngine;
using System;

public class StackSpawner : MonoBehaviour
{
    //Create a stack of piece layers of predefined height
    //Call the random piece placer on these piece layers

    #region Properties

    [SerializeField] int stackHeight = 5;           //Number of stack layers to be placed
    [SerializeField] int stacksLeft = 0;
    [SerializeField] GameObject pieceLayerGO;       //Actual Piece Layer Prefab
    [SerializeField] float distanceBetweenLayers;   //The distance between the piece layers

    [SerializeField] bool infiniteGeneration;

    [SerializeField] AddLayerChannelSO addLayerChannelSO;
    [SerializeField] WindowChannelSO windowChannelSO;

    private Vector2 initialPosition;
    private ObjectPooler pooler;

    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        //References
        pooler = ObjectPooler.instance;

        //Init
        initialPosition = transform.position;
        stacksLeft = stackHeight;

        //Create Stack when the game starts
        CreateStack(stackHeight);
    }

    private void OnEnable()
    {
        if (infiniteGeneration) addLayerChannelSO.EAddPieceLayerAtBottom += AddPieceAtBottom;

        addLayerChannelSO.EAddPieceLayerAtBottom += StackCount;
    }

    private void OnDisable()
    {
        if (infiniteGeneration) addLayerChannelSO.EAddPieceLayerAtBottom -= AddPieceAtBottom;

        addLayerChannelSO.EAddPieceLayerAtBottom -= StackCount;
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

    private void StackCount()
    {
        stacksLeft -= 1;

        if (stacksLeft <= 0)
        {
            windowChannelSO.RaiseWinUIEvent();
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

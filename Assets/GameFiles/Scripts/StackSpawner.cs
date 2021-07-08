using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    //Create a stack of piece layers of predefined height
    //Call the random piece placer on these piece layers

    #region Properties

    [SerializeField] int stackHeight = 5;           //Number of stack layers to be placed
    [SerializeField] GameObject pieceLayerGO;       //Actual Piece Layer Prefab
    [SerializeField] float distanceBetweenLayers;   //The distance between the piece layers

    private ObjectPooler pooler;

    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        //References
        pooler = ObjectPooler.instance;

        //Create Stack when the game starts
        CreateStack(stackHeight);
    }
    #endregion

    #region Private Functions

    //Creates a stack of piece layers of predefined height
    private void CreateStack(int stackHeight)
    {
        for (int i = 0; i < stackHeight; i++)
        {
            float yVal = transform.position.y - distanceBetweenLayers * i;

            //Create the layer
            GameObject g = pooler.GetGameObjectFromPool(PoolObjectType.PIECELAYER);
            g.transform.parent = this.transform;
            g.transform.position = new Vector3(0, yVal, 0);
            g.SetActive(true);

            //Generate the random piece arrangement
            PieceSpawner spawner = g.GetComponent<PieceSpawner>();
            spawner.SpawnPieces();
        }
    }

    #endregion

    #region Public Functions

    public void AddPieceLayerToBottom()
    {
        GameObject g = pooler.GetGameObjectFromPool(PoolObjectType.PIECELAYER);
        g.transform.parent = this.transform;
        g.transform.position = new Vector3(0, transform.position.y - stackHeight * distanceBetweenLayers, 0);
        g.SetActive(true);
    }

    #endregion
}

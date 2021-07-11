using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    //Create a pool of gameobjects at startup
    //return the required gameobject from the pool when asked for
    //Create new objects for the pool if the current pool is filled

    #region Properties

    //Singleton
    public static ObjectPooler instance = null;

    [SerializeField] List<PoolObject> poolObjects;                    //Objects whose pool has to be created
    [SerializeField] Dictionary<string, GameObject> poolObjectCache = new Dictionary<string, GameObject>();  //For faster fetching of gameObjects

    //Pools
    [SerializeField, Space] List<GameObject> normalPool = new List<GameObject>();
    [SerializeField] List<GameObject> dangerPool = new List<GameObject>();
    [SerializeField] List<GameObject> particlePool = new List<GameObject>();
    [SerializeField] List<GameObject> pieceLayerPool = new List<GameObject>();

    #endregion

    #region MonobehavioursFunctions
    private void Awake()
    {
        #region  Maintain single instance
        if (instance == null) instance = this;
        else Destroy(gameObject);
        #endregion
    }

    private void Start()
    {
        //Create Cache
        foreach (PoolObject item in poolObjects)
        {
            item.SetPoolObjectVariation();
            poolObjectCache.Add(item.poolObjectName, item.poolObject);
        }

        InitializePool();
    }
    #endregion

    #region Private Functions

    //Creates initial pool 
    private void InitializePool()
    {
        //Create pool for every pool object
        foreach (PoolObject poolObject in poolObjects)
        {
            int poolSize = poolObject.poolSize;

            for (int i = 0; i < poolSize; i++)
            {
                CreatePoolObject(poolObject);
            }
        }
    }

    private GameObject CreatePoolObject(PoolObject poolObject)
    {
        //Create an instance of the pool object
        GameObject g = Instantiate(poolObject.poolObject, Vector3.zero, Quaternion.identity, transform);
        g.SetActive(false);

        //Add the created pool Object to their pool
        switch (poolObject.poolObjectName)
        {
            case "Normal":
                normalPool.Add(g);
                return g;
            case "Danger":
                dangerPool.Add(g);
                return g;
            case "Particle":
                particlePool.Add(g);
                return g;
            case "PieceLayer":
                pieceLayerPool.Add(g);
                return g;
            default:
                Debug.LogWarning("A Pool Object was created but there was no pool for it", gameObject);
                return null;
        }
    }

    private GameObject CreatePoolObject(PoolObjectType type)
    {
        GameObject g;

        switch (type)
        {
            case PoolObjectType.NORMAL:
                g = Instantiate(poolObjectCache["Normal"], Vector3.zero, Quaternion.identity, transform);
                g.SetActive(false);
                normalPool.Add(g);
                return g;

            case PoolObjectType.DANGER:
                g = Instantiate(poolObjectCache["Danger"], Vector3.zero, Quaternion.identity, transform);
                g.SetActive(false);
                dangerPool.Add(g);
                return g;

            case PoolObjectType.PARTICLE:
                g = Instantiate(poolObjectCache["Particle"], Vector3.zero, Quaternion.identity, transform);
                g.SetActive(false);
                particlePool.Add(g);
                return g;

            case PoolObjectType.PIECELAYER:
                g = Instantiate(poolObjectCache["PieceLayer"], Vector3.zero, Quaternion.identity);
                g.SetActive(false);
                pieceLayerPool.Add(g);
                return g;

            default:
                Debug.LogWarning("A Pool Object was created but there was no pool for it", gameObject);
                return null;
        }
    }


    //Returns a valid poolObect from the pool
    public GameObject GetGameObjectFromPool(PoolObjectType type)
    {
        //Check for a valid pool object in the pool
        switch (type)
        {
            case PoolObjectType.NORMAL:

                foreach (GameObject g in normalPool)
                {
                    if (g != null && g.activeInHierarchy == false)
                    {
                        return g;
                    }
                }
                break;

            case PoolObjectType.DANGER:

                foreach (GameObject g in dangerPool)
                {
                    if (g != null && g.activeInHierarchy == false)
                    {
                        return g;
                    }
                }
                break;

            case PoolObjectType.PARTICLE:

                foreach (GameObject g in particlePool)
                {
                    if (g != null && g.activeInHierarchy == false)
                    {
                        return g;
                    }
                }
                break;

            case PoolObjectType.PIECELAYER:

                foreach (GameObject g in pieceLayerPool)
                {
                    if (g != null && g.activeInHierarchy == false)
                    {
                        return g;
                    }
                }
                break;

            default:
                Debug.LogError("The reqested pool object doesnot exist", gameObject);
                return null;
        }

        //Since pool is filled, create an instant of the object and return it
        return CreatePoolObject(type);
    }

    #endregion

    #region Public Functions

    #endregion
}

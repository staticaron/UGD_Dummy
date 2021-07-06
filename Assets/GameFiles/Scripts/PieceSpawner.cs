using UnityEngine;
using System.Collections.Generic;

public class PieceSpawner : MonoBehaviour
{
    #region Properties
    [SerializeField] Transform spawnPointsHolder;
    [SerializeField] Transform pieceHolder;
    [SerializeField] List<Transform> points;

    [SerializeField, Space] GameObject normalPiece;
    [SerializeField] GameObject dangerPiece;

    [SerializeField, Space] int normalPercentage;
    [SerializeField] int dangerPercentage;

    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        SpawnPieces();
    }
    #endregion

    #region Private Functions
    private void SpawnPieces()
    {
        foreach (Transform t in points)
        {
            //TODO : Object Pooling

            Instantiate<GameObject>(GetRandomPiece(), t.position, t.rotation, pieceHolder);
        }
    }

    private GameObject GetRandomPiece()
    {
        int randInt = Random.Range(0, 100);

        if (randInt >= 0 && randInt < normalPercentage)
        {
            return normalPiece;
        }
        else if (randInt >= normalPercentage && randInt < 100)
        {
            return dangerPiece;
        }
        else
        {
            Debug.LogError("Error returning piece");
            return null;
        }
    }

    #endregion

    #region Public Functions

    #endregion
}

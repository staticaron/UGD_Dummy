using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] bool persistance = false;

    private void Awake()
    {
        if (persistance)
        {
            //Prevent the Managers from getting destroyed
            DontDestroyOnLoad(gameObject);
        }
    }
}
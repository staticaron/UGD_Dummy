using UnityEngine;

public class Manager : MonoBehaviour
{
    //Singletons
    public static Manager instance;

    [SerializeField] bool persistance = false;

    private void Awake()
    {
        if (persistance)
        {
            //Prevent the Managers from getting destroyed
            DontDestroyOnLoad(gameObject);
        }

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
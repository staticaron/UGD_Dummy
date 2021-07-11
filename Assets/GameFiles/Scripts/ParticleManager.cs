using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    #region Properties
    [SerializeField] ParticleChannelSO particleChannelSO;

    [SerializeField, Space] Material noramlMaterial;
    [SerializeField] Material dangerMaterial;
    [SerializeField] Material ballMaterial;

    private ObjectPooler pooler;
    #endregion

    #region MonobehavioursFunctions
    private void Start()
    {
        pooler = ObjectPooler.instance;
    }

    private void OnEnable()
    {
        particleChannelSO.EInstantiateParticle += InstantiateParticle;
    }

    private void OnDisable()
    {
        particleChannelSO.EInstantiateParticle -= InstantiateParticle;
    }
    #endregion

    #region Private Functions
    private void InstantiateParticle(ParticleType type, Transform t)
    {
        GameObject particleRequest = pooler.GetGameObjectFromPool(PoolObjectType.PARTICLE);

        particleRequest.transform.position = t.position;
        particleRequest.transform.rotation = t.rotation;

        //Set the appropriate material to the particle
        if (type == ParticleType.NORMAL)
        {
            particleRequest.GetComponent<ParticleSystemRenderer>().material = noramlMaterial;
        }
        else if (type == ParticleType.DANGER)
        {
            particleRequest.GetComponent<ParticleSystemRenderer>().material = dangerMaterial;
        }
        else if (type == ParticleType.BALL)
        {
            particleRequest.GetComponent<ParticleSystemRenderer>().material = ballMaterial;
        }

        particleRequest.SetActive(true);
    }
    #endregion

    #region Public Functions

    #endregion
}

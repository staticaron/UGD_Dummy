using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ParticleChannelSO", menuName = "UGD_Dummy/ParticleChannelSO", order = 0)]
public class ParticleChannelSO : ScriptableObject
{
    public delegate void InstantiateParticle(ParticleType type, Transform t);
    public event InstantiateParticle EInstantiateParticle;

    public void RaiseEvent(ParticleType type, Transform t)
    {
        if (EInstantiateParticle != null)
        {
            EInstantiateParticle(type, t);
        }
        else
        {
            Debug.LogWarning("Instantiate Particle was raised but no one was listening to it");
        }
    }
}
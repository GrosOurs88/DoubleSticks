using UnityEngine;

[CreateAssetMenu(fileName = "TargetScriptableObject", menuName = "Scriptable Objects/TargetScriptableObject")]
public class TargetScriptableObject : ScriptableObject
{
    public float timer;
    public ParticleSystem particleSystemDestruction;
    public ParticleSystem particleSystemDamage;
}

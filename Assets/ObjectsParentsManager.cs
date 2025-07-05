using UnityEngine;

public class ObjectsParentsManager : MonoBehaviour
{
    public Transform particleEffectsParent;

    public static ObjectsParentsManager instance;

    private void Awake()
    {
        instance = this;
    }
}

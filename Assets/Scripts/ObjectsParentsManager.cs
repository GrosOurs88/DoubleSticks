using UnityEngine;

public class ObjectsParentsManager : MonoBehaviour
{
    public Transform particleEffectsParent;
    public Transform canvasTargetsParent;

    public static ObjectsParentsManager instance;

    private void Awake()
    {
        instance = this;
    }
}

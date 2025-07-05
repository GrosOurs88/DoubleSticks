using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public TargetScriptableObject targetSO;
    public Image targetTimer;
    public string tagNeededToBeDestroyed = "";
    private float remainingTime;
    private ObjectsParentsManager objectsParentsManager;

    private void OnEnable()
    {
        objectsParentsManager = ObjectsParentsManager.instance;
        remainingTime = targetSO.timer;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        targetTimer.fillAmount = remainingTime / targetSO.timer;

        if(remainingTime < 0.0f)
        {
            remainingTime = 0.0f;
            DealDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagNeededToBeDestroyed)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
       // Instantiate(targetSO.particleSystemDestruction, transform.position, Quaternion.identity, objectsParentsManager.particleEffectsParent);
        Destroy(gameObject);
    }

    private void DealDamage()
    {
       // Instantiate(targetSO.particleSystemDamage, transform.position, Quaternion.identity, objectsParentsManager.particleEffectsParent);
        Destroy(gameObject);
    }
}

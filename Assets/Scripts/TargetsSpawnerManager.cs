using UnityEngine;

public class TargetsSpawnerManager : MonoBehaviour
{
    public GameObject targetBluePrefab;
    public GameObject targetRedPrefab;
    public GameObject targetPurplePrefab;
    public float timeBetweenSpawnTarget = 2.0f;
    private float timer = 0.0f;

    private WeaponsManager WeaponsManager;
    private ObjectsParentsManager objectsParentsManager;

    private void Start()
    {
        WeaponsManager = WeaponsManager.instance;
        objectsParentsManager = ObjectsParentsManager.instance;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeBetweenSpawnTarget)
        {
            int randomNumber = Random.Range(0, 3);

            if(randomNumber == 0)
            {
                Vector2 randomPosition = new Vector2(Random.Range(0.0f, WeaponsManager.screenWidth/2.0f),
                                                     Random.Range(0.0f, WeaponsManager.screenHeight));

                Instantiate(targetBluePrefab, randomPosition, Quaternion.identity, objectsParentsManager.canvasTargetsParent);
            }

            else if(randomNumber == 1)
            {
                Vector2 randomPosition = new Vector2(Random.Range(WeaponsManager.screenWidth/2.0f, WeaponsManager.screenWidth),
                                                     Random.Range(0.0f, WeaponsManager.screenHeight));

                Instantiate(targetRedPrefab, randomPosition, Quaternion.identity, objectsParentsManager.canvasTargetsParent);
            }

            else if(randomNumber == 2)
            {
                Vector2 randomPosition = new Vector2(Random.Range(WeaponsManager.screenWidth/3.0f, WeaponsManager.screenWidth/1.5f),
                                                     Random.Range(0.0f, WeaponsManager.screenHeight));

                Instantiate(targetRedPrefab, randomPosition, Quaternion.identity, objectsParentsManager.canvasTargetsParent);
            }
            
            timer = 0.0f;
        }
    }
}

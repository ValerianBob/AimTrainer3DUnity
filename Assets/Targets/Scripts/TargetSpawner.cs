using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    private GameManager _gameManager;

    public float spawnSpeed = 0.5f;

    private int randomAreaToSpawn = 0;

    public bool startSpawn = true;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (startSpawn && _gameManager.GameStart)
        {
            spawnSpeed = _gameManager.GetSpawnSpeed();
            StartCoroutine("SpawnTarget");
            startSpawn = false;
        }
        else if (!_gameManager.GameStart)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);

            randomAreaToSpawn = Random.Range(0,4);

            if (randomAreaToSpawn == 0)
            {
                Instantiate(targetPrefab, new Vector3(Random.Range(20f, 85f), Random.Range(2f, 7f), Random.Range(60f, 85f)),
                                targetPrefab.transform.rotation);
            }
            else if (randomAreaToSpawn == 1)
            {
                Instantiate(targetPrefab, new Vector3(Random.Range(60f, 85f), Random.Range(2f, 7f), Random.Range(15f, 85f)),
                                targetPrefab.transform.rotation);
            }
            else if (randomAreaToSpawn == 2)
            {
                Instantiate(targetPrefab, new Vector3(Random.Range(20f, 85f), Random.Range(2f, 7f), Random.Range(15f, 40f)),
                                targetPrefab.transform.rotation);
            }
            else if (randomAreaToSpawn == 3)
            {
                Instantiate(targetPrefab, new Vector3(Random.Range(15f, 40f), Random.Range(2f, 7f), Random.Range(15f, 85f)),
                                targetPrefab.transform.rotation);
            }

            Score.instance.AddTotalSpawnedTargets();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner _spawnerInstance;

    [SerializeField] List<GameObject> EnemyList;
    float randomYPos;

    //keep only 1 instance of the EnemySpawner class
    private void Awake()
    {
        if (_spawnerInstance == null)
        {
            _spawnerInstance = this;
        }
        else if (_spawnerInstance != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    IEnumerator EnemySpawnerCoroutine()
    {
        //default value
        int enemyToSpawn = 0;
        float waitTime = 2.5f;

        switch (GameData.CurrentLevel)
        {
            case GameData._currentLevel.Level2:
                waitTime = 2f;
                enemyToSpawn = 1;
                break;

            case GameData._currentLevel.Level3:
                waitTime = 1.5f;
                enemyToSpawn = 2;
                break;
        }

        while (true)
        {
            randomYPos = Random.Range(GameData.YMin+4f, GameData.YMax-2f);
            Instantiate(EnemyList[enemyToSpawn], new Vector3(this.transform.position.x, randomYPos), Quaternion.identity);

            yield return new WaitForSeconds(waitTime);
        }
    }
}

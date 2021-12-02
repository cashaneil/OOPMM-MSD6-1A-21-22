using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner _spawnerInstance;

    [SerializeField] List<GameObject> EnemyList;
    int randomEnemy;
    float randomXPos;

    private void Awake()
    {
        if (_spawnerInstance == null)
        {
            _spawnerInstance = this;
        }
        else if(_spawnerInstance != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawnerCoroutine()
    {
        while(true)
        {
            randomEnemy = Random.Range(0, EnemyList.Count); //spawn a random enemy from list of enemies
            randomXPos = Random.Range(GameData.XMin, GameData.XMax); //spawn chosen enemy in random x position according to GameData xmin and xmax
            Instantiate(EnemyList[randomEnemy], new Vector3(randomXPos, GameData.YMax + 1f), Quaternion.identity);

            yield return new WaitForSeconds(2.5f);
        }
    }
}

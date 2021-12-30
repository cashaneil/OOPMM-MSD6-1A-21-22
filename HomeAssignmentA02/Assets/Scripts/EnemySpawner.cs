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

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawnerCoroutine()
    {
        while (true)
        {
            randomYPos = Random.Range(GameData.YMin+2f, GameData.YMax-2f);
            Instantiate(EnemyList[0], new Vector3(this.transform.position.x, randomYPos), Quaternion.identity);

            yield return new WaitForSeconds(2.5f);
        }
    }
}

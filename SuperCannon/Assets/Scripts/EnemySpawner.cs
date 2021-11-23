using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemyList;
    float randomXPos;
    int randomEnemy;

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
            randomEnemy = Random.Range(0, EnemyList.Count);
            randomXPos = Random.Range(GameData.GetXMin(), GameData.GetXMax());
            GameObject mylargebullet = Instantiate(EnemyList[randomEnemy], new Vector3(randomXPos, GameData.GetYMax() + 1f), Quaternion.identity);

            yield return new WaitForSeconds(2.5f);
        }
    }
}

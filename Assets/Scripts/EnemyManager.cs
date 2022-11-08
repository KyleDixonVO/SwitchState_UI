using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;
    public int maxEnemies;
    public float lowerBoundsX;
    public float lowerBoundsY;
    public float lowerBoundsZ;
    public float upperBoundsX;
    public int upperBoundsY;
    public float upperBoundsZ;
    public List<GameObject> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Count);
            GameObject temp = Instantiate(enemyPrefab, new Vector3((spawnPoints[spawnPoint].transform.position.x + Random.Range(-2, 2)), spawnPoints[spawnPoint].transform.position.y, (spawnPoints[spawnPoint].transform.position.z + Random.Range(-2, 2))), gameObject.transform.rotation);
            Debug.Log(spawnPoint);
            enemyList.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpawnPositions()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Count);
            Debug.Log(spawnPoint);
            enemyList[i].transform.position = new Vector3(spawnPoints[spawnPoint].transform.position.x + Random.Range(-2, 2), spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z + Random.Range(-2, 2));
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(spawnPoints[i].transform.position, .5f);
        }   
    }
}

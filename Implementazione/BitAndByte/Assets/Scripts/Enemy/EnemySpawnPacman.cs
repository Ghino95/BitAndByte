using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPacman : MonoBehaviour {

    public List<GameObject> Object;

    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(Object[Random.Range(0, Object.Capacity)], tr.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            yield return null;
        }
    }
}

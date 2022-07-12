using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform myParent;
    public int maxAsteroids = 20;
    public int activeAsteroids =0;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        while (activeAsteroids < maxAsteroids)
        {
            SpawnAsteroid();
            activeAsteroids++;
        }
    }
    private void SpawnAsteroid()
    {
        float x = Random.Range((int)transform.position.x - 15, (int)transform.position.x + 15);
        Vector3 pos = new Vector3(x, transform.position.y + 20, 0);

        GameObject new_asteroid = Instantiate(
            myPrefab,
            transform.position,
            transform.rotation
        );
        new_asteroid.transform.position = pos;
        
    }

}

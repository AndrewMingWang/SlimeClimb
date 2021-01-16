using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{

    public Camera camera;

    public GameObject rockPrefab;
    public GameObject player;


    private float _timeSinceLastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        _timeSinceLastSpawn = 0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timeSinceLastSpawn++;
        if (_timeSinceLastSpawn > 20)
        {
            // random timing
            System.Random rnd = new System.Random();
            int chance = rnd.Next(1, 60);
            if (chance == 1)
            {
                SpawnRandomRock();
                _timeSinceLastSpawn = 0;
            }
        }
    }

    private void SpawnRandomRock()
    {
        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, player.transform.position.z));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, player.transform.position.z));
        Vector3 position = new Vector3(Random.Range(-15, 15), camera.transform.position.y + 15, player.transform.position.z);
        GameObject newRock = Instantiate(rockPrefab, position, Random.rotation);
    }

}

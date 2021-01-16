using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnRock : MonoBehaviour
{

    private GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        rock = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (rock.transform.position.y < -50)
        {
            Destroy(rock);
        }

    }
}

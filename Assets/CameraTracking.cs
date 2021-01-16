using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    public GameObject player;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera.GetComponent<Transform>().position = new Vector3(camera.transform.position.x, player.transform.position.y + 2.5f, camera.transform.position.z);
    }
}

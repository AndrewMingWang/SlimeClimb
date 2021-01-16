using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.tag == "Player")
        {

            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 0), ForceMode.VelocityChange);
            collision.gameObject.GetComponent<Rigidbody>().ResetInertiaTensor();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -50, 0), ForceMode.VelocityChange);
            collision.gameObject.GetComponent<SlimeMovement>().Stun();
            collision.gameObject.GetComponent<SlimeMovement>().HitSound.Play();
        }
    }
}

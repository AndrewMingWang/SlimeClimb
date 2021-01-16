using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathChecks : MonoBehaviour
{

    public GameObject player;
    public Text endtext;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < -15 || player.transform.position.x > 15 || player.transform.position.y < -40)
        {
            endtext.text = "You fell off the mountain :c \n" +
                scoreText.text;
            Time.timeScale = 0;
        }
    }
}

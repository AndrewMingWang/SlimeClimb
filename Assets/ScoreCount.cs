using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{

    private int score;
    private int lastheight;
    private int currheight;

    public GameObject player;
    public Text playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lastheight = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currheight = (int)player.transform.position.y;
        if (currheight > lastheight + 1)
        {
            score++;
        } else if (currheight < lastheight - 1)
        {
            score--;
        }

        playerScoreText.text = "Score: " + score;
        lastheight = currheight;
    }
}

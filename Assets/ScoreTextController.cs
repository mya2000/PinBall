using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTextController : MonoBehaviour
{
    private GameObject scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = "Score" + score;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LargeStarTag")
        {
            score = score + 20;
        }
        else if (other.gameObject.tag == "SmallStarTag")
        {
            score = score + 10;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score = score + 15;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score = score + 30;
        }
    }
}

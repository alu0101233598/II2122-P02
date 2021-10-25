using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void updateScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}

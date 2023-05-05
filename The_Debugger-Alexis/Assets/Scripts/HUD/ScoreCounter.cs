using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text Score_text;

    public static ScoreCounter instance;

    private int score = 0;

    private void Start()
    {
        Score_text.text = score.ToString();
    }


    private void Awake()
    {
        instance = this;
    }


    internal void UpdateScoreNormalSpider()
    {
        ScoreCounter.instance.score = ScoreCounter.instance.score + 50;
        score = ScoreCounter.instance.score;
        Score_text.text = score.ToString();
    }

    internal void UpdateScoreHornet()
    {
        ScoreCounter.instance.score = ScoreCounter.instance.score + 100;
        score = ScoreCounter.instance.score;
        Score_text.text = score.ToString();
    }

    internal void UpdateScoreHeavySpider()
    {
        ScoreCounter.instance.score = ScoreCounter.instance.score + 200;
        score = ScoreCounter.instance.score;
        Score_text.text = score.ToString();
    }

    internal void UpdateScoreMatriarch()
    {
        ScoreCounter.instance.score = ScoreCounter.instance.score + 500;
        score = ScoreCounter.instance.score;
        Score_text.text = score.ToString();
    }
}

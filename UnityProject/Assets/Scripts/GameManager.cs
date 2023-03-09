using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] TMP_Text GameScoreUI;
    [SerializeField] Button scorebutton;
    private float score;
    private int levels = 0;
    public bool gameOver { get; set; }

	private void Start()
	{
        scorebutton.onClick.AddListener(() => GetScore());
	}

	public void AddScore(float score)
    {
        this.score += score;
		this.score = Mathf.Round(this.score * 100f) / 100f;
		scoreUI.text = "$" + this.score;
    }

    public string GetScore()
	{
		return score.ToString() + ":" + levels.ToString();
    }

    public void Level()
    {
        levels++;
    }

    public int getLevel()
    {
        return levels;
    }

    public void SetGameOver()
    {
        gameOver = true;
        scoreUI.enabled = false;
        GameOverUI.SetActive(true);
        GameScoreUI.text = "$" + this.score;
	}
}

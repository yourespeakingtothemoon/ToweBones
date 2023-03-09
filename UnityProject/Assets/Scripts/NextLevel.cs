using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{ 
			CompleteLevel();
		}
	}

	private void CompleteLevel()
	{
		var scene = (int)Random.Range(1, 4);
		while (scene == SceneManager.GetActiveScene().buildIndex)
		{
			scene = (int)Random.Range(1, 4);
		}
		FindObjectOfType<GameManager>().Level();
		SceneManager.LoadScene(scene);
	}
}

using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to switch scenes

public class LevelManager : MonoBehaviour {
	public static LevelManager levelManager;
	public int CurrentSceneIndex;
	public int score;
	// Use this for initialization


	public void LoadLevel(string name)
	{
		
		SceneManager.LoadScene(name);
	}

	public void EndGame()
	{
		
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);  //load the next level depends on build settings

	}
	public void LoadStart()
	{
		SceneManager.LoadScene(0); //Load the default scene
	}
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(FindObjectOfType<score>())FindObjectOfType<score>().setScore(score);	 //find the score object
	
		if(scene.buildIndex == 0)  //Restart the game
		{
			score = 0;
		}
	}
	void Awake()
	{
	if (levelManager == null) //To search the level manager is is null,level manager is this level manager
	{
			DontDestroyOnLoad(gameObject);
	levelManager = this;
		}
        else if (levelManager != this) //To avoid conflictions of the multiple level managers
		{
		Destroy(gameObject);
		}
	}
}
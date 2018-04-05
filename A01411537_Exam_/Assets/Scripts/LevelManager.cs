using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	//public int bricks = player.breakableCount;
	public int CurrentSceneIndex;

	// The change the scene
	public void LoadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}
	void Update () {
		CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

	}


	// To quit the application
	public void EndGame() {
		Application.Quit();
	}
	public void LoadNextLevel(){
		//  Reset the number of breakable bricks in the scene to 0





		//  Load the next scene in the build order
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


}

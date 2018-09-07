using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	// ==================================
	public void Play()
	{
		// Load settings from saved file?
		GameInstance.gameLevelIndex = 0;

		SceneManager.LoadScene(SceneNames.GAME_BASE);
	}

	// ==================================
	public void Quit()
	{
		Application.Quit();
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public GameObject deathScreen;

    private MusicManager musicManager;

	private void Start()
	{
		instance = this;

		this.deathScreen.SetActive(false);
        this.musicManager = FindObjectOfType<MusicManager>();

		// StartCoroutine(this.LoadCurrentLevel(false));

        this.musicManager.PlayRandomMusic();
	}

	// ===================================
	public void ShowDeathScreen()
	{
		this.deathScreen.SetActive(true);
	}

	// ===================================
	public void LoadMainMenu()
	{
		SceneManager.LoadScene(SceneNames.MAIN_MENU, LoadSceneMode.Single);
	}

	// ===================================
	public void LoadNextLevel()
	{
		StartCoroutine(this.LoadCurrentLevel(true));
        this.musicManager.PlayRandomMusic();
	}

	// ===================================
	public void ReloadLevel()
	{
		StartCoroutine(this.LoadCurrentLevel(false));
	}

	// ===================================
	public IEnumerator LoadCurrentLevel(bool next)
	{
		Scene scn = SceneManager.GetSceneByName(
			SceneNames.LEVELS[
				GameInstance.gameLevelIndex
			]
		);

		AsyncOperation loading;


		// Unloads the current scene
		if (scn.isLoaded)
		{
			loading = SceneManager.UnloadSceneAsync(scn);

			while (!loading.isDone)
			{
				yield return null;
			}
		}

		if (next)
		{
			GameInstance.gameLevelIndex++;
		}

		// Loads the current scene index
		this.deathScreen.SetActive(false);
		loading = SceneManager.LoadSceneAsync(
			SceneNames.LEVELS[
				GameInstance.gameLevelIndex
			],
			LoadSceneMode.Additive
		);

		while (!loading.isDone)
		{
			yield return null;
		}
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public GameObject deathScreen;

	private void Awake()
	{
		instance = this;

		this.deathScreen.SetActive(false);

		StartCoroutine(this.LoadCurrentLevel());
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
		GameInstance.gameLevelIndex++;
		StartCoroutine(this.LoadCurrentLevel());
	}

	// ===================================
	public void ReloadLevel()
	{
		StartCoroutine(this.LoadCurrentLevel());
	}

	// ===================================
	public IEnumerator LoadCurrentLevel()
	{
		Debug.Log(GameInstance.gameLevelIndex);
		Debug.Log(SceneNames.LEVELS[
				GameInstance.gameLevelIndex
			]);
		Scene scn = SceneManager.GetSceneByName(
			SceneNames.LEVELS[
				GameInstance.gameLevelIndex
			]
		);

		AsyncOperation loading;


		if (scn.isLoaded)
		{
			loading = SceneManager.UnloadSceneAsync(scn);

			while (!loading.isDone)
			{
				yield return null;
			}
		}

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

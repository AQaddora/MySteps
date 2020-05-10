using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class LevelSelector : MonoBehaviour
{
	public GameObject bottomBar;
	public string[] scenes;

	int level, sublevel;

	static bool isFirstTime = true;
	public AudioClip girlsIntroduction, boysIntroduction;

	void Start()
	{
		if (bottomBar == null) return;
		if(SceneManager.GetActiveScene().buildIndex == 0 && isFirstTime)
		{
			isFirstTime = false;
			bottomBar.SetActive(false);
			AudioManager.Instance.IntroTalk(girlsIntroduction, boysIntroduction);
		}

		SceneManager.sceneLoaded += (delegate {
			if (SceneManager.GetActiveScene().buildIndex == 0)
			{
				bottomBar.SetActive(false);
			}
			else
			{
				bottomBar.SetActive(true);
			}
			Debug.Log("Scene Loaded");
		});
		
	}

	public void SetLevel(int level)
	{
		this.level = level;
	}
	public void SetSubLevel(int sublevel)
	{
		this.sublevel = sublevel;
		SceneManager.LoadScene(sublevel + level);
	}

	public void HomeButton()
	{
		if(Admop.Instance != null) Admop.Instance.showInterstitial();
		AudioManager.Instance.EndAnimationsAndVoice();
		SceneManager.LoadScene(0);
	}
	public void LoadNextLevel()
	{
		if (Admop.Instance != null) Admop.Instance.showInterstitial();
		int next = SceneManager.GetActiveScene().buildIndex + 1;
		if (!IsSameCatagory(next))
			next = 0;

		AudioManager.Instance.EndAnimationsAndVoice();
		SceneManager.LoadScene(next);
	}

	public void LoadPreviousLevel()
	{
		if (Admop.Instance != null) Admop.Instance.showInterstitial();
		int pre = SceneManager.GetActiveScene().buildIndex - 1;
		if (!IsSameCatagory(pre))
			pre = 0;

		AudioManager.Instance.EndAnimationsAndVoice();
		SceneManager.LoadScene(pre);
	}

	public void ExitButton()
	{
		if (AudioManager.isTalking)
		{
			AudioManager.Instance.EndAnimationsAndVoice();
		}
		else
		{
			Debug.Log("Quit();");
			Application.Quit();
		}
	}
	public void LoadSceneByName(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	private bool IsSameCatagory(int sceneindex)
	{
		if (sceneindex > scenes.Length - 1) return false;
		string scene = scenes[sceneindex];
		string thisScene = SceneManager.GetActiveScene().name;
		return scene == thisScene.Substring(0,2);
	}
}

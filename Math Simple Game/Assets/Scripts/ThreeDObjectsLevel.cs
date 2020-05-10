using UnityEngine;

public class ThreeDObjectsLevel : MonoBehaviour
{
	private int levelIndex = 0;
	public Level[] levels;
	
	void Start()
    {
		foreach (Level level in levels)
		{
			level.DeActivate();
		}
		levels[levelIndex].Activate();
    }

	public void Answer(bool isTrue)
	{
		if(!isTrue)
		{
			AudioManager.Instance.PlayWrongEffect();
			return;
		}
		else
		{
			AudioManager.Instance.PlayTrueEffect();
			if (!levels[levelIndex].SetNextQuestion())
			{
				levelIndex++;
				if(levelIndex >= levels.Length)
				{
					FindObjectOfType<LevelSelector>().LoadNextLevel();
					return;
				}
				foreach (Level level in levels)
				{
					level.DeActivate();
				}
				levels[levelIndex].Activate();
			}
		}
	}
}

[System.Serializable]
public class Level
{
	public GameObject _3dObject;
	public GameObject[] questions;
	private int index = 0;

	public void DeActivate()
	{
		_3dObject.SetActive(false);
		foreach (GameObject gameObject in questions)
		{
			gameObject.SetActive(false);
		}
	}

	public void Activate()
	{
		_3dObject.SetActive(true);
		foreach (GameObject gameObject in questions)
		{
			gameObject.SetActive(false);
		}
		questions[0].SetActive(true);
	}

	public bool SetNextQuestion()
	{
		if(++index >= questions.Length)
		{
			return false;
		}
		foreach (GameObject gameObject in questions)
		{
			gameObject.SetActive(false);
		}
		questions[index].SetActive(true);
		return true;
	}
}

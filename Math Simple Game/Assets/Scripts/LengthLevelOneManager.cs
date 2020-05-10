using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LengthLevelOneManager : MonoBehaviour
{
	public static LengthLevelOneManager Instance;


	private void Awake()
	{
		Instance = this;
	}

	[SerializeField] Fader[] stages;

	private static int counter;

	public int Counter
	{
		get { return counter; }
		set {
			if(value > counter)
			{
				AudioManager.Instance.PlayTrueEffect();
			}
			counter = value;
			if (counter == 2)
			{
				foreach (Fader fader in stages)
				{
					fader.Hide();
				}
				stages[1].Show();
			}else if (counter == 3)
			{
				foreach (Fader fader in stages)
				{
					fader.Hide();
				}
				stages[2].Show();
			}
			else if (counter == 4)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}

	public void WrongEffect()
	{
		AudioManager.Instance.PlayWrongEffect();
	}
	public void TrueEffect()
	{
		AudioManager.Instance.PlayTrueEffect();
	}

	public void LoadNextLevel()
	{
		FindObjectOfType<LevelSelector>().LoadNextLevel();
	}
}

using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
	public static LevelOneManager Instance;

	public Fader dayTimeBG, nightTimeBG;
	public Animation sun, moon;

	[SerializeField] AudioClip endClip;

	private Animator animator;

	private void Awake()
	{
		Instance = this;
		animator = GetComponent<Animator>();
		sun.Play();
	}

	public void ReloadScene_TESTING_ONLY()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	public void DayCycle()
	{
		if (dayTimeBG.cg.alpha >= 0.5f)
		{
			dayTimeBG.Hide();
			nightTimeBG.Show();
			moon.Play();
		}
		else
		{
			dayTimeBG.Show();
			nightTimeBG.Hide();
			sun.Play();
		}
	}
}

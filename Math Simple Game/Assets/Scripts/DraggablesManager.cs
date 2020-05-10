using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggablesManager : MonoBehaviour
{
	public static DraggablesManager Instance;

	[SerializeField] GameObject nextStage;
	[SerializeField] Fader preStage;
	public int correctItemsThreshold;
	public float sensetivity = 25;
	public bool loadHomeAfter = false;
	[SerializeField] AudioClip correctSFX;
	[SerializeField] AudioClip wrongSFX;
	[SerializeField] AudioClip endClip;

	private int counter = 0;
	void Awake()
    {
		Instance = this;
    }
	public void End()
	{
		AudioManager.Instance.PlayEffect(endClip);
		counter = 0;
		if(nextStage != null && !nextStage.activeInHierarchy)
		{
			preStage.Hide();
			nextStage.SetActive(true);
		}
		else
		{
			if (loadHomeAfter)
				SceneManager.LoadScene(0);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void TrueEffect()
	{
		if (++counter >= correctItemsThreshold)
		{
			End();
			return;
		}
		AudioManager.Instance.PlayTrueEffect();
	}

	public void FalseEffect()
	{
		AudioManager.Instance.PlayWrongEffect();
	}
}

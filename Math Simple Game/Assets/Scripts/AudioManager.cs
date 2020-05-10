using UnityEngine;
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	public AudioClip[] trueSfx;
	public AudioClip[] wrongSfx;

	public TalkAnimation boyTalkAnimation; 
	public TalkAnimation girlTalkAnimation;

	public Fader bgFader, girlFader, boyFader;

	public static bool isTalking = false;
	public AudioSource musicSource;
	public AudioSource sfxSource;

    void Awake()
    {
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
    }

	public void Talk(AudioClip speech, bool isBoy)
	{
		if (speech == null)
			return;

		CancelInvoke();
		isTalking = true;
		musicSource.volume = 0.02f;
		PlayEffect(speech);
		if (isBoy)
		{
			boyFader.Show();
			boyFader.gameObject.SetActive(true); 
			girlFader.gameObject.SetActive(false);
			bgFader.Show();
			boyTalkAnimation.StartAnimation();
		}
		else
		{
			girlFader.Show();
			girlFader.gameObject.SetActive(true);
			boyFader.gameObject.SetActive(false);
			bgFader.Show();
			girlTalkAnimation.StartAnimation();
		}
		PlayEffect(speech);
		Invoke("EndAnimationsAndVoice", speech.length);
	}


	public void IntroTalk(AudioClip girl, AudioClip boy)
	{
		isTalking = true;
		first = girl;
		second = boy;
		bgFader.Show();
		girlFader.Show();
		boyFader.Hide();
		girlTalkAnimation.StartAnimation();
		girlFader.gameObject.SetActive(true);
		Invoke("PlayFirst", bgFader.duration);
		Invoke("PlaySecondClip", girl.length);
	}

	AudioClip first, second;
	private object girlF;

	void PlayFirst()
	{
		musicSource.volume = 0.02f;
		PlayEffect(first);
	}
	void PlaySecondClip()
	{
		girlFader.Hide();
		girlTalkAnimation.EndAnimation();
		boyFader.gameObject.SetActive(true);
		boyFader.Show();
		boyTalkAnimation.StartAnimation();
		PlayEffect(second);
		Invoke("EndAnimationsAndVoice", second.length);
	}

	public void EndAnimationsAndVoice()
	{
		CancelInvoke();
		isTalking = false;
		musicSource.volume = 0.1f;
		girlTalkAnimation.EndAnimation();
		boyTalkAnimation.EndAnimation();
		girlFader.Hide();
		boyFader.Hide();
		bgFader.Hide();
		sfxSource.Stop();
	}



	public void PlayEffect(AudioClip clip)
	{
		sfxSource.PlayOneShot(clip, 1f);
	}

	public void PlayTrueEffect()
	{
		sfxSource.Stop();
		sfxSource.PlayOneShot(trueSfx[Random.Range(0, trueSfx.Length)], 1f);
	}

	public void PlayWrongEffect()
	{
		sfxSource.Stop();
		sfxSource.PlayOneShot(wrongSfx[Random.Range(0, wrongSfx.Length)], 1f);
	}
}

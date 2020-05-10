using UnityEngine;

public class TalkManager : MonoBehaviour
{
	public bool isTalkingAtTheBeginning = false;
	public AudioClip speech;
	public bool isBoy = false;
    // Start is called before the first frame update
    void OnEnable()
    {
		if (isTalkingAtTheBeginning)
		{
			AudioManager.Instance.Talk(speech, isBoy);
		}    
    }
}

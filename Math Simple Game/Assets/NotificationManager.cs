using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class NotificationManager : MonoBehaviour
{
	public static NotificationManager Instance;

	public Text title;
	public Text description;
	public Image bg;
	public Color error, green, info;

	private void Awake()
	{
		Instance = this;
	}
	public void ShowNotification(string title, string des, bool isError)
	{
		GetComponent<Fader>().CancelInvoke();
		description.text = ArabicFixer.Fix(des);
		this.title.text = ArabicFixer.Fix(title);
		bg.color = isError ? error : green;
		GetComponent<Fader>().Show();
		GetComponent<Fader>().Invoke("Hide", 3);
	}
	public void ShowNotification(string title, string des, bool isInfo, float timer)
	{
		GetComponent<Fader>().CancelInvoke();
		description.text = ArabicFixer.Fix(des);
		this.title.text = ArabicFixer.Fix(title);
		bg.color = isInfo ? info : green;
		GetComponent<Fader>().Show();
		GetComponent<Fader>().Invoke("Hide", timer);
	}
}

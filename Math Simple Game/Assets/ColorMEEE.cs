using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorMEEE : MonoBehaviour
{
	private void Start()
	{
		EventTrigger myTrigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener((eventData) => { ChangeMyColor(); });
		myTrigger.triggers.Add(entry);
	}
	public void ChangeMyColor()
	{
		GetComponent<Image>().color = Color.red;
	}
}

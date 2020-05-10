using UnityEngine;
using UnityEngine.EventSystems;

public class MatchPoint : MonoBehaviour
{
    void Start()
	{
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener((eventData) => { OnPointerEnter(); });
		trigger.triggers.Add(entry);
	}
	public void OnPointerEnter()
	{

	}
}
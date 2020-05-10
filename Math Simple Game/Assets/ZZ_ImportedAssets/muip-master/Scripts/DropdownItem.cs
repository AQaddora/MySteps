using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownItem : MonoBehaviour {

	[Header("RESOURCES")]
	public CustomDropdown mainScript;
	public string itemText;
	public string itemSelectionNumber;
	public Sprite itemImage;

	[Header("OBJECTS")]
	public Text itemTextObj;
	public Image itemImageObj;

	[Header("SETTINGS")]
	public bool SetImageFromScript = false;
	public bool SetTextFromScript = true;
	public bool isMins;

	void Start () 
	{
		if (SetImageFromScript == false) 
		{
			itemImage = itemImageObj.sprite;
		}

		if (SetTextFromScript == false) 
		{
			itemText = itemTextObj.text;
		}

		itemTextObj.text = itemText;
		itemImageObj.sprite = itemImage;
	}

	public void ItemClick ()
	{
		if (mainScript.rememberSelection == true) 
		{
			PlayerPrefs.SetString (mainScript.DropdownID + "SelectedText", itemText);
			PlayerPrefs.SetString (mainScript.DropdownID + "SelectedImage", itemImageObj.sprite.name);
		}

		mainScript.selectedText.text = itemText;

		if (isMins) FindObjectOfType<LevelTwoManager>().SetMinsString(itemSelectionNumber);
		else FindObjectOfType<LevelTwoManager>().SetHoursString(itemSelectionNumber);
	}
}
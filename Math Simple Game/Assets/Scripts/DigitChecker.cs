using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;
using System.Collections;

public class DigitChecker : MonoBehaviour
{
	Hashtable ArEnNumbers = new Hashtable();
	[SerializeField] private string correctInput;
	[SerializeField] private AudioClip correctEffect, falseEffect;

	private InputField input;

	[HideInInspector] public bool correct = false;
	void Awake()
	{
		ArEnNumbers.Add(ArabicNumber(0), "0");
		ArEnNumbers.Add(ArabicNumber(1), "1");
		ArEnNumbers.Add(ArabicNumber(2), "2");
		ArEnNumbers.Add(ArabicNumber(3), "3");
		ArEnNumbers.Add(ArabicNumber(4), "4");
		ArEnNumbers.Add(ArabicNumber(5), "5");
		ArEnNumbers.Add(ArabicNumber(6), "6");
		ArEnNumbers.Add(ArabicNumber(7), "7");
		ArEnNumbers.Add(ArabicNumber(8), "8");
		ArEnNumbers.Add(ArabicNumber(9), "9");

		input = GetComponent<InputField>();
		input.onEndEdit.AddListener(delegate { OnEndEdit(); });
	}

	public void OnEndEdit()
	{
		if (CheckNumber(input.text.Trim()).Equals(correctInput))
		{
			correct = true;
			input.contentType = InputField.ContentType.Standard;
			input.interactable = false;
			AudioManager.Instance.PlayEffect(correctEffect);
			Debug.Log(ArabicFixer.Fix(input.text, false, true) + " <<");
			input.text = ArabicFixer.Fix(input.text, false, true);
			foreach (DigitChecker d in FindObjectsOfType<DigitChecker>())
			{
				if (!d.correct)
					return;

				FindObjectOfType<LevelSelector>().LoadNextLevel();
			}
		}
		else
		{
			AudioManager.Instance.PlayEffect(falseEffect);
			input.text = "";
		}
	}

	string CheckNumber(string text)
	{
		if (string.IsNullOrEmpty(text) || text.Length > 2)
		{
			Debug.Log(text.Length);
			return text;
		}
		else if (text[0] <= '9' && text[0] >= '0')
		{
			Debug.Log("First char of " + text + " is a digit");
			return text;
		}
		else
		{
			string numberIs = "";
			if (text.Length == 2)
			{
				numberIs = ((string)ArEnNumbers[text[0] + ""]) + ((string)ArEnNumbers[text[1] + ""]);
			}
			else
			{
				numberIs = ((string)ArEnNumbers[text[0] + ""]);
			}
			Debug.Log(text + ">>" + numberIs);
			return numberIs;
		}
	}

	string ArabicNumber(int num)
	{
		return ArabicFixer.Fix(num + "", false, true);
	}
}

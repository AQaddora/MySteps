using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTwoManager : MonoBehaviour
{
	private int index = 0;
	public GameObject[] clocks;
	public InputField hoursAnswer, minutesAnswer;

	private void Awake()
	{
		hoursAnswer.text = "00";
		if (minutesAnswer != null) minutesAnswer.text = "00";
		foreach (GameObject obj in clocks)
		{
			obj.SetActive(false);
		}
		clocks[index].SetActive(true);
	}
	public void GoButton() 
	{
		if (string.IsNullOrEmpty(hoursAnswer.text) || (minutesAnswer != null && string.IsNullOrEmpty(minutesAnswer.text)))
			return;

		string answer;
		if(minutesAnswer != null)
			answer = hoursAnswer.text.Trim() + ":" + minutesAnswer.text.Trim();
		else
			answer = hoursAnswer.text.Trim();

		hoursAnswer.text = "00";
		if (minutesAnswer != null) minutesAnswer.text = "00";

		Debug.Log(answer + "   :    " + clocks[index].name);
		if (answer==(clocks[index].name))
		{
			AudioManager.Instance.PlayTrueEffect();
			NextQuestion();
		}
		else
		{
			AudioManager.Instance.PlayWrongEffect();
		}
	}

	public void SetHoursString(string hours)
	{
		hoursAnswer.text = hours;
		Debug.Log(hoursAnswer.text);
	}

	public void SetMinsString(string mins)
	{
		minutesAnswer.text = mins;
		Debug.Log(minutesAnswer.text);
	}

	void NextQuestion()
	{
		index++;
		if(index >= clocks.Length)
		{
			//MOVE TO NEXT LEVEL() :'D
			int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
			SceneManager.LoadScene(sceneToLoad);
			return;
		}
		
		foreach (GameObject obj in clocks)
		{
			obj.SetActive(false);
		}
		clocks[index].SetActive(true);
	}

	public void FixHoursInput(string input)
	{
		if(input.Length == 2 && input[0] == '0')
		{
			hoursAnswer.text = input[1] + "";
		}
	}

	public void FixMinutesInput(string input)
	{
		if (input.Length == 1)
			minutesAnswer.text = "0" + input;
	}
}

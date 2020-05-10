using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lengthLevel2Manager : MonoBehaviour
{
	public static lengthLevel2Manager Instance;

	public Fader[] stages;
	private int counter;

	private void Awake()
	{
		Instance = this;
	}

	public void NextStage()
	{
		foreach (Fader fader in stages)
		{
			fader.Hide();
		}
		counter++;
		if (counter < 4)
			stages[counter].Show();
		else
		{
			counter = 0;
			FindObjectOfType<LevelSelector>().LoadNextLevel();
		}
	}
}

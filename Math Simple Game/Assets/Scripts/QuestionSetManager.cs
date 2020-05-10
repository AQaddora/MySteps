using UnityEngine;

public class QuestionSetManager : MonoBehaviour
{
	public Fader nextQuestionSet;
	public bool CheckIfQuestionSetFinished()
	{
		foreach (InputChecker input in GetComponentsInChildren<InputChecker>())
		{
			if (!input.correct) return false;
		}
		if(nextQuestionSet != null)
		{
			GetComponent<Fader>().Hide();
			nextQuestionSet.Show();
		}
		else
		{
			FindObjectOfType<LevelSelector>().LoadNextLevel();
		}
		return true;
	}
}

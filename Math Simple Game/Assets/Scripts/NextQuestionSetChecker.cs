using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextQuestionSetChecker : MonoBehaviour
{
	public Fader toShow;
	private void Awake()
	{
		GetComponent<Button>().transition = Selectable.Transition.None;
		GetComponent<Button>().onClick.AddListener(delegate
		{
			if (GetComponentInParent<QuestionSetManager>().CheckIfQuestionSetFinished())
			{
				if(toShow != null)
				{
					toShow.Show();
					GetComponentInParent<Fader>().Hide();
					Destroy(transform.parent.gameObject, GetComponentInParent<Fader>().duration);
				}
				else
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
				}
			}
		});
	}
}

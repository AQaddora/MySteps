using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CM_Question : MonoBehaviour
{	
	bool hasAlreadyCheckedThis = false;
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<Button>().onClick.AddListener(delegate 
		{
			if (hasAlreadyCheckedThis)
				return;

			GetComponent<Animation>().Play();
			hasAlreadyCheckedThis = true;
			LengthLevelOneManager.Instance.Counter++;
		});
    }
}

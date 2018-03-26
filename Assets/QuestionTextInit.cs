using UnityEngine.UI;
using UnityEngine;

public class QuestionTextInit : MonoBehaviour {

    [SerializeField] Text QuestionPanelText;
    [Space]
    [SerializeField]
    [TextArea(2,10)]
    private string question;

	// Use this for initialization
	void Start () {
        
	}
	
    public void SetQuestionText()
    {
        QuestionPanelText.text = question;
    }
}

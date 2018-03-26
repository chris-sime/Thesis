using UnityEngine.UI;
using UnityEngine;

public class QuestionQuiz : MonoBehaviour {

    [SerializeField] Text QuestionPanelText;
    [Space]
    [SerializeField]
    [TextArea(2,10)]
    private string question;

	// Use this for initialization
	void Start () {
        QuestionPanelText.text = question;
	}
	
    public void CorrectAnswer()
    {

    }
}

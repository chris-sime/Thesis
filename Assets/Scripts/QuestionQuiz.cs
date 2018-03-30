using System.Collections.Generic;
using UnityEngine;

public class QuestionQuiz : MonoBehaviour
{

    [SerializeField]
    List<GameObject> Questions = new List<GameObject>();
    [SerializeField]
    List<GameObject> Tries = new List<GameObject>();
    [SerializeField]
    List<GameObject> NumberOfQuestionsToShow = new List<GameObject>();


    int rng;
    // Use this for initialization
    void Start()
    {
        foreach (var question in Questions)
        {
            question.SetActive(false);
        }
        PickNextQuestion();
    }
    
    public void CorrectAnswer()
    {
        int r = Random.Range(0, NumberOfQuestionsToShow.Count);
        NumberOfQuestionsToShow[r].SetActive(false);
        NumberOfQuestionsToShow.RemoveAt(r);
        Questions[rng].SetActive(false);
        Questions.RemoveAt(rng);
        if (NumberOfQuestionsToShow.Count <= 0)
        {
            UIManager.instance.ShowInfoPanel("Συγχαρητήρια!", "Κατάφερες να νικήσεις τον στρατό του Δαριού", true);
        }
        else
        { 
            PickNextQuestion();
        }
    }

    public void WrongAnswer()
    {
        int r = Random.Range(0, Tries.Count);
        Tries[r].SetActive(false);
        Tries.RemoveAt(r);
        if (Tries.Count <= 0)
        {
            UIManager.instance.ShowInfoPanel("Ωχ, όχι!", "Δε κατάφερες να νικήσεις τον Δάριο σε αυτήν τη μάχη", true);
        }
    }
    public void PickNextQuestion()
    {
        if(Questions.Count != 0)
        {
            rng = Random.Range(0, Questions.Count);
            Questions[rng].GetComponent<QuestionTextInit>().SetQuestionText();
            Questions[rng].SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GameUI : MonoBehaviour
{
    private VisualElement gameUI;
    private Label scoreCounter;
    private Label timeCounter;    

    private void OnEnable()
    {
        gameUI = GetComponent<UIDocument>().rootVisualElement;
        scoreCounter = gameUI.Q<Label>("ScoreCounter");   

        Player.OnScoreCollectedEvent += PrintScore;
    }  
    private void OnDisable() => Player.OnScoreCollectedEvent -= PrintScore;

    private void PrintScore(int currentScore)
    {
       scoreCounter.text = $"SCORE: {currentScore}";
    }    
}

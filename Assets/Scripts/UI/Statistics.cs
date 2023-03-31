using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class Statistics : MonoBehaviour
{
   private VisualElement rootVisualElement;
   private Label totalScoreCounter;
   private Label deathCounter;
   private Button backButton;

   private void OnEnable()
   {
      rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

      totalScoreCounter = rootVisualElement.Q<Label>("TotalScoreCount");
      deathCounter = rootVisualElement.Q<Label>("DeathCount");
      backButton = rootVisualElement.Q<Button>("BackButton");
      ShowStatistics();
   }

   private void ShowStatistics()
   {
      PlayerData data = (PlayerData)SaveSystem.LoadPlayerStats();      
      totalScoreCounter.text = $"TOTAL SCORE: {data.score}";
      deathCounter.text = $"DEATH COUNT: 0";
   }   
}

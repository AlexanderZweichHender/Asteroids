using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset statisticsButtonsTemplate;
    private VisualElement statisticsButtons;
    private VisualElement buttonsWrapper;
    private UIDocument menuScreen;

    private Button statisticsButton;
    private Button backButton;
    private Button playButton;
    private Button exitGameButton;

    private Label totalScoreCount;
    private Label deathCount;

    private void OnEnable()
    {
        menuScreen = GetComponent<UIDocument>();        
        buttonsWrapper = menuScreen.rootVisualElement.Q<VisualElement>("ButtonsPanel");

        statisticsButton = menuScreen.rootVisualElement.Q<Button>("StatisticsButton");
        statisticsButton.clicked += StatisticsButtonOnClicked;

        statisticsButtons = statisticsButtonsTemplate.CloneTree();    
        backButton = statisticsButtons.Q<Button>("BackButton");
        backButton.clicked += OnBackButtonClicked;

        totalScoreCount = statisticsButtons.Q<Label>("TotalScore");
        deathCount = statisticsButtons.Q<Label>("DeathCount");

        playButton = menuScreen.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += StartGame; 

        exitGameButton = menuScreen.rootVisualElement.Q<Button>("ExitGameButton");
        exitGameButton.clicked += ExitGame;     
    }

    private void OnDisable()
    {
        statisticsButton.clicked -= StatisticsButtonOnClicked;
        playButton.clicked -= StartGame;
        exitGameButton.clicked -= ExitGame;
    }

    private void StatisticsButtonOnClicked()
    {
        buttonsWrapper.Clear();
        buttonsWrapper.Add(statisticsButtons);
        ShowStatistics();        
    }

    private void OnBackButtonClicked()
    {
        buttonsWrapper.Clear();
        buttonsWrapper.Add(playButton);
        buttonsWrapper.Add(statisticsButton);
        buttonsWrapper.Add(exitGameButton);    
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void ShowStatistics()
    {
        PlayerData data = (PlayerData)SaveSystem.LoadPlayerStats();        
        totalScoreCount.text = $"TOTAL SCORE: {data.score}";
        deathCount.text = $"DEATH COUNT: {data.deathCount}";
    }
}

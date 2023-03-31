using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class PauseUI : MonoBehaviour
{
    private VisualElement rootVisualElement;

    private Button goToMenuButton;    
    private Button exitGameButton;    

    private void OnEnable()
    {
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        goToMenuButton = rootVisualElement.Q<Button>("GoToMenuButton");
        exitGameButton = rootVisualElement.Q<Button>("ExitGameButton");

        goToMenuButton.clicked += GoToMenuButtonOnClicked;
        exitGameButton.clicked += ExitGameButtonOnClicked;
    }

    private void OnDisable()
    {
        goToMenuButton.clicked -= GoToMenuButtonOnClicked;
        exitGameButton.clicked -= ExitGameButtonOnClicked;
    }

    private void GoToMenuButtonOnClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void ExitGameButtonOnClicked()
    {
#if UNITY_EDITOR        
        UnityEditor.EditorApplication.isPlaying = false;
#endif        
        Application.Quit();
    }
}   

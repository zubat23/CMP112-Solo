using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIcontrollerTitleScreen : MonoBehaviour
{
    private Button StartButton;
    private Button QuitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        StartButton = root.Q<Button>("Start__button");
        QuitButton = root.Q<Button>("Quit__button");

        StartButton.clicked += OnStartClicked;
        QuitButton.clicked += OnQuitClicked;
    }

    void OnStartClicked()
    {
        SceneManager.LoadScene("Main Scene");
    }
    void OnQuitClicked()
    {
        Application.Quit();
    }
}

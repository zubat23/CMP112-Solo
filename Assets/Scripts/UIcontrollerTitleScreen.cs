using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIcontrollerTitleScreen : MonoBehaviour
{
    private Button StartButton;
    private Button QuitButton;

    private AudioSource buttonSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        buttonSound = GetComponent<AudioSource>();

        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get button references
        StartButton = root.Q<Button>("Start__button");
        QuitButton = root.Q<Button>("Quit__button");

        //Assign button functions
        StartButton.clicked += OnStartClicked;
        QuitButton.clicked += OnQuitClicked;
    }

    void OnStartClicked()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Main Scene");
    }
    void OnQuitClicked()
    {
        buttonSound.Play();
        Application.Quit();
    }
}

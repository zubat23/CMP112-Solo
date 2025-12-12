using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class deathScreenUI : MonoBehaviour
{
    private Button RestartButton;
    private Button MainMenuButton;

    private Label scoreLabel;

    private AudioSource buttonSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        var root = GetComponent<UIDocument>().rootVisualElement;

        RestartButton = root.Q<Button>("Restart__button");
        MainMenuButton = root.Q<Button>("Back__button");

        scoreLabel = root.Q<Label>("score__label");

        RestartButton.clicked += OnRestartClicked;
        MainMenuButton.clicked += OnMainMenuClicked;

        scoreLabel.text = (Global.enemiesDefeated + 1).ToString() + " was Too Many Bears!";
    }

    void OnRestartClicked()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Main Scene");
    }

    void OnMainMenuClicked()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Title Screen");
    }

}

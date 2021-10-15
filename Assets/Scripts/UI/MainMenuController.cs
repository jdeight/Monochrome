using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Monochrome.UI
{
    public class MainMenuController : MonoBehaviour
    {
        Button playBtn;
        Button controlsBtn;
        Button optionsBtn;
        Button quitBtn;


        private void Awake()
        {
            Transform buttonContainer = transform.Find("MainMenuContainer").Find("ButtonContainer");
            playBtn = buttonContainer.Find("PlayButton").GetComponent<Button>();
            controlsBtn = buttonContainer.Find("HowToPlayButton").GetComponent<Button>();
            optionsBtn = buttonContainer.Find("OptionsButton").GetComponent<Button>();
            quitBtn = buttonContainer.Find("QuitButton").GetComponent<Button>();
        }

        private void Start()
        {
            playBtn.onClick.AddListener(OnPlayClicked);
            controlsBtn.onClick.AddListener(OnControlsClicked);
            optionsBtn.onClick.AddListener(OnOptionsClicked);
            #if UNITY_STANDALONE || UNITY_EDITOR
            quitBtn.onClick.AddListener(OnQuitClicked);
            #else
            quitBtn.gameObject.SetActive(false);
            #endif
        }

        private void OnPlayClicked()
        {
            SceneManager.LoadScene("Tutorial");
        }

        private void OnControlsClicked()
        {
        }

        private void OnOptionsClicked()
        {
        }

        private void OnQuitClicked()
        {
            #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

    }
}
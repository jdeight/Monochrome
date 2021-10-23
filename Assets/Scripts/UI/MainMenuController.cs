using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Monochrome.UI
{
    public class MainMenuController : MonoBehaviour
    {
        private Button _playBtn;
        private Button _controlsBtn;
        private Button _optionsBtn;
        private Button _quitBtn;


        private void Awake()
        {
            Transform buttonContainer = transform.Find("MainMenuContainer").Find("ButtonContainer");
            _playBtn = buttonContainer.Find("PlayButton").GetComponent<Button>();
            _controlsBtn = buttonContainer.Find("HowToPlayButton").GetComponent<Button>();
            _optionsBtn = buttonContainer.Find("OptionsButton").GetComponent<Button>();
            _quitBtn = buttonContainer.Find("QuitButton").GetComponent<Button>();
        }

        private void Start()
        {
            _playBtn.onClick.AddListener(OnPlayClicked);
            _controlsBtn.onClick.AddListener(OnControlsClicked);
            _optionsBtn.onClick.AddListener(OnOptionsClicked);
            #if UNITY_STANDALONE || UNITY_EDITOR
            _quitBtn.onClick.AddListener(OnQuitClicked);
            #else
            quitBtn.gameObject.SetActive(false);
            #endif
        }

        private static void OnPlayClicked()
        {
            SceneManager.LoadScene("Tutorial");
        }

        private static void OnControlsClicked()
        {
        }

        private static void OnOptionsClicked()
        {
        }

        private static void OnQuitClicked()
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
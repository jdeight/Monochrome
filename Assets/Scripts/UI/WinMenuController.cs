using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Monochrome.UI
{
    public class WinMenuController : MonoBehaviour
    {
        private GameObject _canvas;

        private Button _mainMenuBtn;

        private void Start()
        {
            _canvas = transform.Find("Canvas").gameObject;
            _mainMenuBtn = transform.Find("Canvas/MainMenuBtn").GetComponent<Button>();
            _mainMenuBtn.onClick.AddListener(OnMainMenuClicked);
        }
        
        private static void OnMainMenuClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void EnableMenu()
        {
            _canvas.SetActive(true);
        }
    }
}

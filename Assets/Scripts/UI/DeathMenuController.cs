using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Monochrome.UI
{
    public class DeathMenuController : MonoBehaviour
    {
        private Transform _respawnPoint;

        private GameObject _player;

        private Button _respawnBtn;
        private Button _mainMenuBtn;
        private GameObject _canvas;
        
        private void Awake()
        {
            Transform root = transform.root;
            _respawnPoint = root.Find("/PlayerRespawn").GetComponent<Transform>();
            _player = root.Find("/Player").gameObject;
        }
        
        private void Start()
        {
            _canvas = transform.Find("Canvas").gameObject;
            _respawnBtn = transform.Find("Canvas/RespawnBtn").GetComponent<Button>();
            _mainMenuBtn = transform.Find("Canvas/MainMenuBtn").GetComponent<Button>();
            
            _respawnBtn.onClick.AddListener(OnRespawnClicked);
            _mainMenuBtn.onClick.AddListener(OnMainMenuClicked);
        }

        private static void OnMainMenuClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void OnRespawnClicked()
        {
            _player.GetComponent<Transform>().position = _respawnPoint.transform.position;
            _player.SetActive(true);
            _canvas.SetActive(false);
        }
        
        public void EnableMenu()
        {
            _canvas.SetActive(true);
        }
    }
}

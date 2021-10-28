using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] private string targetScene;
    private GameObject fader;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Player hit level transition. Moving to scene [" + targetScene + "]");
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(targetScene);
    }
}

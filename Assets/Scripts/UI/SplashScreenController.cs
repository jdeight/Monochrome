using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monochrome.UI
{
    public class SplashScreenController : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Splash());
        }

        private IEnumerator Splash()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}

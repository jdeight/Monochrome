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

        private static IEnumerator Splash()
        {
            yield return new WaitForSeconds(1.8f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}

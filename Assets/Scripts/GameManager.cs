using UnityEngine;

namespace Monochrome
{
    public class GameManager : MonoBehaviour
    {

        public static bool IsPaused = false;
        public static bool CanPause = false;

        private void Awake()
        {
            #if UNITY_EDITOR
            QualitySettings.vSyncCount = 0;  // VSync must be disabled
            Application.targetFrameRate = 200;
            #endif

            Debug.Log("GameManager initialized.");
        }

    }
}

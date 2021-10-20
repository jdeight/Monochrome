using UnityEngine;

namespace Monochrome
{
    public class GameManager : MonoBehaviour
    {

        public static bool IsPaused = false;
        public static bool CanPause = false;

        public static bool ColorShift = false;

        #if UNITY_EDITOR
        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 200;

            Debug.Log("GameManager initialized.");
        }
        #endif

    }
}

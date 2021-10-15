using UnityEngine;

namespace Monochrome
{
    public class GameManager : MonoBehaviour
    {

        public static bool IsPaused = false;
        public static bool CanPause = false;

        private void Awake()
        {
            Debug.Log("GameManager initialized.");
        }

    }
}

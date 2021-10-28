using Monochrome.UI;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    private WinMenuController _winScreen;

    private void Awake()
    {
        _winScreen = gameObject.GetComponent<WinMenuController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        _winScreen.EnableMenu();
    }
}

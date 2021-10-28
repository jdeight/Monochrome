using Monochrome.UI;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private DeathMenuController _deathScreen;
    
    private void Awake()
    {
        _deathScreen = transform.root.Find("/DeathMenu").GetComponent<DeathMenuController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Player triggered death-box");
        other.gameObject.SetActive(false);
        _deathScreen.EnableMenu();
    }
}

using Monochrome;
using Monochrome.UI;
using UnityEngine;

public class Spikes : ColorSwapController
{
    private DeathMenuController _deathScreen;
    
    private new void Awake()
    {
        base.Awake();
        _deathScreen = transform.root.Find("/DeathMenu").GetComponent<DeathMenuController>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || SpriteRenderer.color != ActiveColor) return;
        other.gameObject.SetActive(false);
        _deathScreen.EnableMenu();
    }
}

using UnityEngine;

namespace Monochrome
{
    public class ColorSwapController : MonoBehaviour
    {
        [SerializeField] private bool startSwapped;

        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;
        
        private Color _activeColor;
        private Color _inactiveColor;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _activeColor = _spriteRenderer.color;
            _inactiveColor = new Color(_activeColor.r, _activeColor.g, _activeColor.b, 0.2f);

            if (!startSwapped) return;
            _spriteRenderer.color = _inactiveColor;
            _boxCollider2D.enabled = false;
        }

        private void FixedUpdate()
        {
            if (GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    _spriteRenderer.color = _activeColor;
                    _boxCollider2D.enabled = true;
                } 
                else 
                {
                    _spriteRenderer.color = _inactiveColor;
                    _boxCollider2D.enabled = false;
                }
            }
            else if (!GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    _spriteRenderer.color = _inactiveColor;
                    _boxCollider2D.enabled = false;
                } 
                else 
                {
                    _spriteRenderer.color = _activeColor;
                    _boxCollider2D.enabled = true;
                }
            }
        }
    }
}

using UnityEngine;

namespace Monochrome
{
    public class ColorSwapController : MonoBehaviour
    {
        [SerializeField] private bool startSwapped;

        protected SpriteRenderer SpriteRenderer;
        private BoxCollider2D _boxCollider2D;
        private CapsuleCollider2D _playerCollider2D;

        protected Color ActiveColor;
        private Color _inactiveColor;

        protected void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _playerCollider2D = FindObjectOfType<PlayerController>().GetComponent<CapsuleCollider2D>();
        }

        private void Start()
        {
            ActiveColor = SpriteRenderer.color;
            _inactiveColor = new Color(ActiveColor.r, ActiveColor.g, ActiveColor.b, 0.2f);

            if (!startSwapped) return;
            SpriteRenderer.color = _inactiveColor;
            Physics2D.IgnoreCollision(_boxCollider2D, _playerCollider2D);
        }

        private void Update()
        {
            if (GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    SpriteRenderer.color = ActiveColor;
                    Physics2D.IgnoreCollision(_playerCollider2D, _boxCollider2D, false);
                } 
                else 
                {
                    SpriteRenderer.color = _inactiveColor;
                    Physics2D.IgnoreCollision(_playerCollider2D, _boxCollider2D);
                }
            }
            else if (!GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    SpriteRenderer.color = _inactiveColor;
                    Physics2D.IgnoreCollision(_playerCollider2D, _boxCollider2D);
                } 
                else 
                {
                    SpriteRenderer.color = ActiveColor;
                    Physics2D.IgnoreCollision(_playerCollider2D, _boxCollider2D, false);
                }
            }
        }
    }
}

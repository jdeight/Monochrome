using UnityEngine;

namespace Monochrome
{
    public class ColorSwapController : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;

        [SerializeField] private bool startSwapped = false;

        private Color activeColor;
        private Color inactiveColor;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            activeColor = spriteRenderer.color;
            inactiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0.2f);

            if (startSwapped)
            {
                spriteRenderer.color = inactiveColor;
                boxCollider2D.enabled = false;
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    spriteRenderer.color = activeColor;
                    boxCollider2D.enabled = true;
                } 
                else 
                {
                    spriteRenderer.color = inactiveColor;
                    boxCollider2D.enabled = false;
                }
            }
            else if (!GameManager.ColorShift)
            {
                if (startSwapped) 
                {
                    spriteRenderer.color = inactiveColor;
                    boxCollider2D.enabled = false;
                } 
                else 
                {
                    spriteRenderer.color = activeColor;
                    boxCollider2D.enabled = true;
                }
            }
        }
    }
}

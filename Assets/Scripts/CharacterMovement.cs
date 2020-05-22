using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput > 0)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (spriteRenderer.flipX) spriteRenderer.flipX = false;
                
                animator.SetFloat("speed", 1);
            }
            else if (horizontalInput < 0)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (!spriteRenderer.flipX) spriteRenderer.flipX = true;

                animator.SetFloat("speed", 1);
            }
            else
            {
                animator.SetFloat("speed", 0);
            }
        }
    }
}

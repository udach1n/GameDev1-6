using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        rigidbody2D.bodyType=RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void RestartLife()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

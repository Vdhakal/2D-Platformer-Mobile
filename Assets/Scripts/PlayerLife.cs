using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator deathAnim;
    private Rigidbody2D rb2D;
    [SerializeField] private AudioSource death;
    // Start is called before the first frame update
    private void Start()
    {
        deathAnim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes")) 
        {
            Die();
        }
    }

    private void Die()
    {
        death.Play();
        deathAnim.SetTrigger("death");
        rb2D.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

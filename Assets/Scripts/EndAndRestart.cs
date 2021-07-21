using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAndRestart : MonoBehaviour
{
    [SerializeField]private Rigidbody2D player;
    [SerializeField]private Animator anim;
    [SerializeField] private AudioSource restart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Example());

    }
    IEnumerator Example()
    {
        restart.Play();
        player.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

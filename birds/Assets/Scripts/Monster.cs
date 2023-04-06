using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            //Die();
            StartCoroutine(ResetAfterDelay1());
        }
      
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }

   /* void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay1());
    } */
    private IEnumerator ResetAfterDelay1()
    {
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        gameObject.SetActive(false);
    }
    /*void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    } */
}

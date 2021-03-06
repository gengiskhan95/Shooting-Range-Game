using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

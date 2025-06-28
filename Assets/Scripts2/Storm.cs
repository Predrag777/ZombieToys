using UnityEngine;

public class StormDamage : MonoBehaviour
{
   
    [SerializeField] private float damage = 10f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
               
            }
        }
    }
}

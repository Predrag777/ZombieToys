using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    private int health = 10;
    private Animator animator;
    private bool isDead = false;

    private float timeToDamage = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            AudioSource.PlayClipAtPoint(audio, transform.position);

            isDead = true;
            animator.SetBool("isDead", true);

            ///Select all enemies and activate idle
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                EnemyAttack2 move = enemies[i].GetComponent<EnemyAttack2>();
                if (move != null)
                {
                    move.setSpeed(0f);
                }
            }
        }

    }


    void changeWeponPrefab()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("enemy"))
        {
            health -= 100;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 100;
        }
    }

}

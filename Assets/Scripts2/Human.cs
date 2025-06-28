using UnityEngine;
using UnityEngine.UI; 

public class Human : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    private int health = 10;
    private Animator animator;
    private bool isDead = false;

    private float timeToDamage = 3f;
    private Image healthbar;

    private float targetFill = 1f;  
    private float fillSpeed = 0.5f;

    void Start()
    {
        GameObject healthbarObj = GameObject.Find("Healthbar");
        if (healthbarObj != null)
        {
            healthbar = healthbarObj.GetComponent<Image>();
        }
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            AudioSource.PlayClipAtPoint(audio, transform.position);

            isDead = true;
            animator.SetBool("isDead", true);

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

        if (healthbar != null)
        {
            float currentFill = healthbar.fillAmount;
            healthbar.fillAmount = Mathf.MoveTowards(currentFill, targetFill, fillSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("enemy"))
        {
            health -= 1;
            UpdateTargetFill();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 100;
            UpdateTargetFill();
        }
    }

    void UpdateTargetFill()
    {
        targetFill = Mathf.Clamp01(health / 100f);
    }
}

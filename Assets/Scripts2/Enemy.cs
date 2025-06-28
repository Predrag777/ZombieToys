using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 10f;
    [SerializeField] private AudioClip deathSound;

    private float soundCooldown = 3f;
    private float timeToDie = 3f;
    Animator animator;
    bool isDead = false;
    int kills = 0;
    public TextMeshProUGUI killsTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        killsTxt = GameObject.Find("killsTxt").GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f && !isDead)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            animator.SetBool("isDead", true);
            isDead = true;
            kills = int.Parse(killsTxt.text);
            kills++;
            Debug.Log("Mrtav");
            killsTxt.text = kills + "";
        }
        if (isDead)
        {
            if (timeToDie <= 0f)
            {
                Destroy(gameObject);
            }
            timeToDie -= Time.deltaTime;
        }

    }


    public void TakeDamage(float damage)
    {
        health -= damage;
    }


}

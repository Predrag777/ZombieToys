using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    private int health = 10;
    private Animator animator;
    private bool isDead = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(audio, transform.position);
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }
}

using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 3f;

    Animator animator;

    private Transform humanPlayer;
    private Enemy enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        humanPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.health>0f)
            MoveTowards();
    }

    void MoveTowards()
    {
        transform.LookAt(humanPlayer);

        transform.position = Vector3.MoveTowards(transform.position, humanPlayer.transform.position, speed);

        float speedMagn = (humanPlayer.position - transform.position).magnitude;
        animator.SetFloat("speed", speedMagn);
    }
}

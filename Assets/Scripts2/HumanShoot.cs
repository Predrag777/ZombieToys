using UnityEngine;

public class HumanShoot : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private Transform crossHair;
    [SerializeField] private Transform shootPosition; // Where bullets would be spawned
    [SerializeField] private ParticleSystem storm;

    [SerializeField] private float distance = 100f;

    [SerializeField] private AudioClip shootSound;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Shoot();
        }
            
    }

    void Shoot()
    {
        Ray ray = new Ray(shootPosition.position, shootPosition.forward);

        storm.transform.position = shootPosition.position;
        storm.transform.rotation = Quaternion.LookRotation(ray.direction);
        storm.Play();

        if (shootSound != null)
    {
        AudioSource.PlayClipAtPoint(shootSound, shootPosition.position);
    }
    }

}

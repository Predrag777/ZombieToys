using UnityEngine;

public class HumanShoot : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private Transform crossHair;
    [SerializeField] private Transform shootPosition; // Where bullets would be spawned
    [SerializeField] private ParticleSystem storm;
    [SerializeField] private ParticleSystem hitEffect; // <-- Dodaj efekat pogotka

    [SerializeField] private float distance = 100f;
    [SerializeField] private AudioClip shootSound;

    void Start()
    {
    }

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
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hitEffect != null)
            {
                hitEffect.transform.position = hit.point;
                hitEffect.transform.rotation = Quaternion.LookRotation(hit.normal);
                hitEffect.Play();
            }

        }

        if (storm != null)
        {
            storm.transform.position = shootPosition.position;
            storm.transform.rotation = Quaternion.LookRotation(ray.direction);
            storm.Play();
        }

        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, shootPosition.position);
        }
    }
}

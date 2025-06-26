using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

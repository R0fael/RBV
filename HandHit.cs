using UnityEngine;

public class HandHit : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            audioSource.clip = other.GetComponent<HitInfo>().audio;
            audioSource.Play();
        }
        catch
        {
            Debug.Log("No Sound");
        }
    }
}

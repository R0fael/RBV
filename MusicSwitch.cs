using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public bool state;
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Tooltip("the tag that button detects")]
    public string tag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Run();
        }
    }
    private void Run()
    {
        if (state) { audioSource.Play(); audioSource.clip = audioClip; } else { audioSource.Stop(); }
    }
}

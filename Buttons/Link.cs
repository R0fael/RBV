using UnityEngine;

public class Link : MonoBehaviour
{
    public string link;
    public string tag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Application.OpenURL(link);
        }
    }
}

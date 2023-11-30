using TMPro;
using UnityEngine;

public class Timed_Opening : MonoBehaviour
{
    public float time_to_open;
    public TextMeshPro text;
    public GameObject door;

    private void Start()
    {
        Invoke(nameof(Open), time_to_open);
    }

    private void Open() => Destroy(door);

    private void Update()
    {
        time_to_open-= Time.deltaTime;
        text.text = ((int)time_to_open + 1).ToString();
    }
}

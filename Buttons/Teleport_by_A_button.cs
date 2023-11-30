using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_by_A_button : MonoBehaviour
{
    public GameObject GorillaPlayer;

    public GameObject RespawnPoint;

    public GameObject[] objects;

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
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
        GorillaPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        GorillaPlayer.transform.position = RespawnPoint.transform.position;
        Invoke(nameof(Waiter), 0.05f);
    }

    void Waiter()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
}

using Photon.Voice;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitCheck : MonoBehaviour
{
    [Header("HitCheck")]
    [Space(32)]
    [Header("Put this script on a player")]
    [Header("This script is made for custom scripts,but it have own functions")]
    [Space(32)]

    [Header("Tags")]
    public string kickTag = "KickHammer";
    public string pushTag = "PushHammer";
    public string HandTag = "HandTag";
    public string FreezeTag = "Freeze";
    public string ScreamObjectTag = "ScreamObject";
    public string SaveZoneTag = "SaveZone";

    [Header("Other")]
    public int tag_counter;
    public GameObject scream;
    public float time_of_scream;
    public bool is_enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(kickTag) && !is_enemy)
        {
            Application.Quit();
            Debug.Log("Kick");
        }
        if (other.CompareTag(pushTag))
        {
            gameObject.transform.parent.GetComponent<Rigidbody>().velocity += other.gameObject.GetComponent<Data>().force;
            gameObject.transform.parent.GetComponent<Rigidbody>().velocity *= other.gameObject.GetComponent<Data>().force_multiplyer;
            gameObject.transform.parent.GetComponent<Rigidbody>().velocity += (other.transform.position - transform.position).normalized * other.gameObject.GetComponent<Data>().force_to_the_player;
            Debug.Log("Boom");
        }
        if (other.CompareTag(HandTag))
        {
            tag_counter++;
            Debug.Log("Tagged");
        }

        if (other.CompareTag(ScreamObjectTag) && !is_enemy)
        {
            Death();
        }

        if (other.CompareTag(FreezeTag))
        {
            transform.parent.GetComponent<Rigidbody>().drag = 100;
            transform.parent.GetComponent<Rigidbody>().angularDrag = 100;
        }
    }

    void Reload()
    {
        Application.Quit();
        SceneManager.LoadScene(0);
    }

    public void Death()
    {
        Debug.Log("Scream");
        if (scream != null)
        {
            scream.SetActive(true);
        }
        Invoke(nameof(Reload), time_of_scream);
    }
}
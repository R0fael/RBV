using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask mask;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new();
        Physics.Raycast(transform.position, transform.forward, out hit);
        if(hit.collider != null)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(10000f, 10000f, 10000f);
        }
    }
}

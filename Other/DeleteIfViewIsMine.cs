 using Photon.Pun;
using UnityEngine;

public class DeleteIfViewIsMine : MonoBehaviour
{
    public PhotonView ptView;
    public GameObject objectX;
    public bool reverse;

    private void OnEnable()
    {
        if(ptView.IsMine)
        {
            objectX.SetActive(false);
        }
    }
    private void Start()
    {
        if (ptView.IsMine)
        {
            objectX.SetActive(reverse ^ false);
        }
        else
        {
            objectX.SetActive(reverse ^ true);
        }
    }
}

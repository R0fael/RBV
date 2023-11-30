using Photon.VR;
using Photon.VR.Cosmetics;
using UnityEngine;

public class SetCosmetic : MonoBehaviour
{
    public enum CosmeticsType { Head, Face, Left, Right, Body, Color }
    [Header("SetCosmetic script")]
    [Space(32)]
    [Tooltip("choose the cosmetic_type")]
    public CosmeticsType type;

    [Tooltip("Cosmetic Name")]
    public string cosmetic_name;
    [Tooltip("Color, if you have chousen color")]
    public Color color;

    [Tooltip("the tag that button detects")]
    public string tag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Run();
        }
    }
    void Run()
    {
        switch (type)
        {
            case CosmeticsType.Head:
                {
                    PhotonVRManager.SetCosmetic(CosmeticType.Head, cosmetic_name);
                    PlayerPrefs.SetString("Head_Cosmetic", cosmetic_name);
                    break;
                }
            case CosmeticsType.Face:
                {
                    PhotonVRManager.SetCosmetic(CosmeticType.Face, cosmetic_name);
                    PlayerPrefs.SetString("Face_Cosmetic", cosmetic_name);
                    break;
                }
            case CosmeticsType.Left:
                {
                    PhotonVRManager.SetCosmetic(CosmeticType.LeftHand, cosmetic_name);
                    PlayerPrefs.SetString("Left_Cosmetic", cosmetic_name);
                    break;
                }
            case CosmeticsType.Right:
                {
                    PhotonVRManager.SetCosmetic(CosmeticType.RightHand, cosmetic_name);
                    break;
                }
            case CosmeticsType.Body:
                {
                    PhotonVRManager.SetCosmetic(CosmeticType.Body, cosmetic_name);
                    PlayerPrefs.SetString("Body_Cosmetic", cosmetic_name);
                    break;
                }
            case CosmeticsType.Color:
                {
                    PhotonVRManager.SetColour(color);
                    PlayerPrefs.SetFloat("red_skin", color.r);
                    PlayerPrefs.SetFloat("red_skin", color.g);
                    PlayerPrefs.SetFloat("red_skin", color.b);
                    break;
                }
        }
    }
}

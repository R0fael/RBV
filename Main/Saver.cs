using Photon.Voice;
using Photon.VR;
using Photon.VR.Cosmetics;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private void Awake()
    {
        Load();
    }
    public void Load()
    {
        PhotonVRManager.SetUsername(PlayerPrefs.GetString("name","No Name"));
        PhotonVRManager.SetColour(new Color(PlayerPrefs.GetFloat("red_skin", 0), PlayerPrefs.GetFloat("green_skin", 0), PlayerPrefs.GetFloat("blue_skin")));
        PhotonVRManager.SetCosmetic(CosmeticType.Head, PlayerPrefs.GetString("Head_Cosmetic", ""));
        PhotonVRManager.SetCosmetic(CosmeticType.Face, PlayerPrefs.GetString("Face_Cosmetic", ""));
        // PhotonVRManager.SetCosmetic(CosmeticType.LeftHand, PlayerPrefs.GetString("Left_Cosmetic", ""));
        // PhotonVRManager.SetCosmetic(CosmeticType.RightHand, PlayerPrefs.GetString("Right_Cosmetic", ""));
        PhotonVRManager.SetCosmetic(CosmeticType.Body, PlayerPrefs.GetString("Body_Cosmetic", ""));
    }
}

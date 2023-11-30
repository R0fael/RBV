using GorillaLocomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public enum Cheat
    {
        LongArm,
        Fly,
    }

    public Cheat type;
    public bool state;
    public GameObject player;
    public GameObject leftHand;
    public GameObject rightHand;
    public float howFar;
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tag))
        {
            switch (type)
            {
                default:
                    Debug.Log("How did you get that far for the cheating?!");
                    break;

                case Cheat.LongArm:
                    if (state)
                    {
                        player.GetComponent<Player>().leftHandOffset = leftHand.transform.forward * howFar;
                        player.GetComponent<Player>().rightHandOffset = rightHand.transform.forward * howFar;
                    }
                    else
                    {
                        player.GetComponent<Player>().leftHandOffset = Vector3.zero;
                        player.GetComponent<Player>().rightHandOffset = Vector3.zero;
                    }
                    break; 

                case Cheat.Fly:
                    if (state)
                    {
                        leftHand.GetComponent<Climb>().enabled = true;
                        rightHand.GetComponent<Climb>().enabled = true;
                    }
                    else
                    {
                        leftHand.GetComponent<Climb>().enabled = false;
                        rightHand.GetComponent<Climb>().enabled = false;
                    }
                    break;
            }
        }
    }
}

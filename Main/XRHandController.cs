using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandType
{
    Left,
    Right
}

public class XRHandController : MonoBehaviour
{
    public HandType handType;
    public float thumbMoveSpeed = 0.1f;

    private Animator animator;
    private InputDevice inputDevice;

    private float pose1Value;
    private float pose2Value;
    private float pose3Value;

    public PhotonView view;

    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();
    }

    void Update()
    {
        if (view.IsMine)
        {
            try
            {
                AnimateHand();
            }
            catch
            {
                // just for nothing...
            }
        }
    }

    InputDevice GetInputDevice()
    {
        InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;

        if (handType == HandType.Left)
        {
            controllerCharacteristic |= InputDeviceCharacteristics.Left;
        }
        else
        {
            controllerCharacteristic |= InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);

        return inputDevices[0];
    }

    void AnimateHand()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out pose1Value);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out pose2Value);

        inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        if (primaryTouched || secondaryTouched)
        {
            pose3Value += thumbMoveSpeed;
        }
        else
        {
            pose3Value -= thumbMoveSpeed;
        }

        pose3Value = Mathf.Clamp(pose3Value, 0, 1);

        if (handType == HandType.Right)
        {
            animator.SetFloat("pose1", pose1Value);
            animator.SetFloat("pose2", pose2Value);
            animator.SetFloat("pose3", pose3Value);
        }
        else
        {
            animator.SetFloat("pose4", pose1Value);
            animator.SetFloat("pose5", pose2Value);
            animator.SetFloat("pose6", pose3Value);
        }
    }
}
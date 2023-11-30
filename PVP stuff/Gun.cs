using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour
{
    public enum HandType
    {
        Left,
        Right
    }
    [Header("Gun Script")]
    public HandType handType;
    public GameObject bullet;
    public Transform shot_point;
    public float speed;
    public float value_of_activation = 0.9f;

    private InputDevice inputDevice;

    private void Awake()
    {
        inputDevice = GetInputDevice();
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

    private void Update()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float x);
        if (x > 0.9f)
        {
            bullet.transform.SetPositionAndRotation(shot_point.position, shot_point.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed);
        }
    }
}

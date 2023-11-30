using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabScript : MonoBehaviour
{
    public GameObject[] list;
    public int old;

    public void Awake()
    {
        foreach (GameObject item in list)
        {
            item.SetActive(false);
        }
        list[0].SetActive(true);
    }

    public void UpdateValue(int new_value)
    {
        if(new_value > list.Length-1)
        {
            new_value = 0;
        }
        if (new_value < 0)
        {
            new_value = list.Length - 1;
        }

        list[old].SetActive(false);
        list[new_value].SetActive(true);
        old = new_value;
    }
}

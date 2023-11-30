using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabChanger : MonoBehaviour
{
    [Space(32)]
    public TabScript tab;
    public new enum TypeOfChange
    {
        Add,
        Set,
    }
    public TypeOfChange type;

    public int value;

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
        if (type.Equals(TypeOfChange.Add))
        {
            tab.UpdateValue(tab.old + value);
        }
        else
        {
            tab.UpdateValue(value);
        }
    }
}

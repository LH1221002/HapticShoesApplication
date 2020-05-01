using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveInActive : MonoBehaviour
{
    public GameObject[] A;
    public GameObject[] B;
    private bool a = true;

    public void ActiveA()
    {
        foreach(GameObject go in A)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in B)
        {
            go.SetActive(false);
        }
        a = false;
    }

    public void ActiveB()
    {
        foreach (GameObject go in A)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in B)
        {
            go.SetActive(true);
        }
        a = true;
    }

    public void Toggle()
    {
        if (a) ActiveA();
        else ActiveB();
    }
}

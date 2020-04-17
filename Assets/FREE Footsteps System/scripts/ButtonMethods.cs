using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public Animator animatorToChange;
    public RuntimeAnimatorController probing;
    public RuntimeAnimatorController walking;

    public GameObject concrete;
    public GameObject wood;
    public GameObject dirt;
    public GameObject sand;
    public GameObject grass;
    public GameObject button;
    public int currentGround = 5;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) ToggleMenu();
    }
    
    public void ToggleMenu()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
    }
    public void ShutDown()
    {
        Application.Quit();
    }
    public void Probing()
    {
        animatorToChange.runtimeAnimatorController = probing;
        //ToDo: ButtonVisualsForAll
    }
    public void Walking()
    {
        animatorToChange.runtimeAnimatorController = walking;
        if (currentGround == 5) ActivateGround(2);
    }
    private void ActivateGround(int id)
    {
        currentGround = id;

        if (concrete) concrete.SetActive(id == 0);
        if (wood) wood.SetActive(id == 1);
        if (dirt) dirt.SetActive(id == 2);
        if (sand) sand.SetActive(id == 3);
        if (grass) grass.SetActive(id == 4);
        if (button) button.SetActive(id == 5);

        if (id == 5) Probing();
    }
    public void Concrete()
    {
        ActivateGround(0);
    }
    public void Wood()
    {
        ActivateGround(1);
    }
    public void Dirt()
    {
        ActivateGround(2);
    }
    public void Sand()
    {
        ActivateGround(3);
    }
    public void Grass()
    {
        ActivateGround(4);
    }
    public void Button()
    { 
        ActivateGround(5);
    }
}

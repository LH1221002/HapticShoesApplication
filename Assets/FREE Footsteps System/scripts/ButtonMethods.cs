using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMethods : MonoBehaviour
{
    public GameObject surfaceButtons;
    public GameObject animationTypeButtons;
    private Button[] SurfaceButtons;
    private Button[] AnimationTypeButtons;

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

    private void Start()
    {
        SurfaceButtons = surfaceButtons.GetComponentsInChildren<Button>();
        AnimationTypeButtons = animationTypeButtons.GetComponentsInChildren<Button>();
    }

    private enum ButtonType{
        surface,
        animation
    }
    private void SetAllButtonsInteractable(ButtonType type)
    {
        foreach(Button b in type==ButtonType.surface ? SurfaceButtons : AnimationTypeButtons)
        {
            b.interactable = true;
        }
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
        SetAllButtonsInteractable(ButtonType.animation);
        animatorToChange.runtimeAnimatorController = walking; //Reset Animation
        animatorToChange.runtimeAnimatorController = probing;
        AnimationTypeButtons[0].interactable = false;
        //ToDo: ButtonVisualsForAll
    }
    public void Walking()
    {
        SetAllButtonsInteractable(ButtonType.animation);
        animatorToChange.runtimeAnimatorController = walking;
        if (currentGround == 5)
        {
            ActivateGround(2);
            SurfaceButtons[2].interactable = false;
        }
    }
    private void ActivateGround(int id)
    {
        SetAllButtonsInteractable(ButtonType.surface);

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

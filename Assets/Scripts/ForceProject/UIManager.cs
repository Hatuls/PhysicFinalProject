using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] Text frcTxt, lftFrcTxt, rightFrcTxt, sFrictionTxt, dFrictionTxt, massTxt, speedTxt;
    [SerializeField] Slider sldr;
    [SerializeField] Slider massSlider;
    [SerializeField] Slider leftForceSlider;
    [SerializeField] Slider rightForceSlider;
    [SerializeField] Slider dynFrictionSlider;
    [SerializeField] Slider sttcFrictionSlider;
    float sldrMidPoint = .5f, lftFrcSldr, rghtFrcSldr;
    private void Start()
    {
        ResetSlider();
    }
    private void Update()
    {
        ForceSliderValues();
        FrictionSliderValues();
        MassSliderValue();
        speedTxt.text = "Speed : " + ForceManager._Instance.GetVelocity;
    }

    private void MassSliderValue()
  => ForceManager._Instance.AddMass(massSlider.value);
    public void UpdateMassTxt() => massTxt.text = "Object Mass Is: " + massSlider.value;
    private void FrictionSliderValues()
    {
        ForceManager._Instance.UpdateFrictions(true, sttcFrictionSlider.value);
        ForceManager._Instance.UpdateFrictions(false, dynFrictionSlider.value);
    }
    public void UpdateFrictionTxt(bool txtToUpdate)
    {
        if (txtToUpdate)
            dFrictionTxt.text = "Dynamic Friction: " + dynFrictionSlider.value;
        else
            sFrictionTxt.text = "Static Friction: " + sttcFrictionSlider.value;
    }

    public void ForceSliderValues()
    {
        if (lftFrcSldr != leftForceSlider.value)
        {
            lftFrcSldr = leftForceSlider.value;
            lftFrcTxt.text = lftFrcSldr + "N";
            ForceManager._Instance.AddLeftForce(leftForceSlider.value);
        }
        if (rghtFrcSldr != rightForceSlider.value)
        {
            rghtFrcSldr = rightForceSlider.value;
            rightFrcTxt.text = rghtFrcSldr + "N";
            ForceManager._Instance.AddRightForce(rightForceSlider.value);
        }

    }
    public void ResetSlider()
    {
        frcTxt.text = "";
        sldr.value = sldrMidPoint;
        leftForceSlider.value = 0;
        rightForceSlider.value = 0;
    }
    public void UpdateSlider(float amount)
    => sldr.value = sldrMidPoint + amount / 200f;
    public void UpdateForceTxt(float amount)
    {
        string txt;
        if (amount < 0)
            txt = "The Sum Of forces is " + amount * -1f + "N";

        else if (amount == 0)
            txt = "The Sum Of Powers is 0N the object wont move";

        else
            txt = "The Sum Of forces is  " + amount + "N";

        frcTxt.text = txt;
    }
}

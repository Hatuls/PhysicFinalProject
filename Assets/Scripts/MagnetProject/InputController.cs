using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    [SerializeField] ChargedParticle leftCharger;
    [SerializeField] ChargedParticle rightCharger;
    [SerializeField] float chargeForce = 15f;
    private void Update()
    {
        ChangeChargeDirection();
    }

    void ChangeChargeDirection()
    {
        float input = Input.GetAxisRaw("Horizontal") * chargeForce;



        if (input> 0)
        {
            leftCharger.UpdateCharge(-input);
            rightCharger.UpdateCharge(0);
        }
        else if (input == 0)
        {
            leftCharger.UpdateCharge(0);
            rightCharger.UpdateCharge(0);
        }

        else
        {
            leftCharger.UpdateCharge(0);
            rightCharger.UpdateCharge(input);
        }
    }

}

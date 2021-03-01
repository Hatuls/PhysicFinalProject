using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoSingleton<ParticleManager>
{
    
    private List<ChargedParticle> chargedParticles;
    private List<MoveChargeParticle> movingChargedParticles;
    private void Start()
    {
        chargedParticles = new List<ChargedParticle>(FindObjectsOfType<ChargedParticle>() );
        movingChargedParticles = new List<MoveChargeParticle>(FindObjectsOfType<MoveChargeParticle>());

        for (int i = 0; i < movingChargedParticles.Count; i++)
        {
            movingChargedParticles[i].LoseCondition += UiHandler._Instance.LoseSection;
        }

        
    }


    private void ApplyMagneticForce(MoveChargeParticle mcp) {
        Vector3 newForce = Vector3.zero;

        foreach (var cp in chargedParticles)
        {
            if (mcp == cp)
                continue;

            float distance = Vector3.Distance(cp.transform.position, mcp.transform.position);
            float force = 1000 * mcp.charge * cp.charge / Mathf.Pow(distance, 2);
            Vector3 direction = (mcp.transform.position - cp.transform.position).normalized;


            newForce += force * direction * Time.fixedDeltaTime;

            if (float.IsNaN(newForce.x))
                newForce = Vector3.zero;

            mcp.GetRB.AddForce(newForce);
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in movingChargedParticles)
            ApplyMagneticForce(item);
    }




    public void ResetGame() {

        for (int i = 0; i < movingChargedParticles.Count; i++)
        {
            movingChargedParticles[i].ReturnToNormal();
        }
        GameManager._Instance.ResetScore();
       
        UiHandler._Instance.ResetUI();
    }
}
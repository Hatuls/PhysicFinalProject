
using UnityEngine;

public class ChargedParticle : MonoBehaviour
{
    public float charge = 1;
  
    private void Start()
    {
        UpdateColor();
    }

    public void UpdateColor()
     =>   GetComponent<Renderer>().material.color = charge > 0 ? Color.green : Color.red;

    public void UpdateCharge(float amount) => charge = amount;
}

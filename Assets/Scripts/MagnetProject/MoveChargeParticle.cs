
using System;
using UnityEngine;

public class MoveChargeParticle : ChargedParticle
{
    public  Action<bool> LoseCondition;
    public float mass = 1;
    Rigidbody rb;
    Vector3 pos;
    public Rigidbody GetRB => rb;

    private void Start()
    {
        UpdateColor();
        pos = transform.position; 
        rb = this.gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity = false;
    }
    public void ReturnToNormal() => transform.position = pos;


    private void OnTriggerEnter(Collider other)
    {
        if (other != this) LoseCondition?.Invoke(true);
    }
}

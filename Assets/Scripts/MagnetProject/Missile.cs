
using System;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Action<GameObject> returnMissileAct;
    public void Init(Action<GameObject> act)
    {
        returnMissileAct += act;
     Rigidbody rb=   gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(-transform.up * UnityEngine.Random.Range(300f,650f));
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    public void ActivateEvent() => returnMissileAct?.Invoke(this.gameObject);
    private void OnCollisionEnter(Collision collision)
    {
        ActivateEvent();
    }
}

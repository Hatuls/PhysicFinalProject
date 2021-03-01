
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ForceManager : MonoSingleton<ForceManager>
{
    [SerializeField] Transform forcedTransform;
    PhysicMaterial objPMat;
    MeshCollider groundCollider;
    BoxCollider objCollider;
    Rigidbody forcedOBJRB;



    Vector3 forceOfObject;
    float leftForce = 0, rightForce = 0;
    Vector3 startPos;

    public void Start()
    {
        forcedOBJRB = forcedTransform.GetComponent<Rigidbody>();
        objCollider = forcedTransform.GetComponent<BoxCollider>();
        objPMat = objCollider.material;
        startPos = forcedTransform.position;
        ReturnPosition();
    }
    public void ResetForces()
=> forceOfObject = Vector3.zero;
    public void ReturnPosition()
    => forcedTransform.position = startPos;
    void AddForce()
    {
        forceOfObject = Vector3.left * (rightForce - leftForce);
        UIManager._Instance.UpdateSlider(forceOfObject.x);
        UIManager._Instance.UpdateForceTxt(forceOfObject.x);
        //Debug.Log("rightForce " + rightForce);
        //Debug.Log("leftForce " + leftForce);
        //Debug.Log(forceOfObject);
        //Debug.Log(forcedOBJRB.velocity);
        forcedOBJRB.AddForce(forceOfObject, ForceMode.Force);
    }
    private void FixedUpdate()
    {
        AddForce();
    }
    public void ResetProgram()
    {
        ReturnPosition();
        ResetForces();
        UIManager._Instance.ResetSlider();
    }
    public void AddLeftForce(float amount)
 => leftForce = amount;
    public void AddRightForce(float amount)
     => rightForce = amount;
    public void AddMass(float mass) {
        if (mass != forcedOBJRB.mass)
        {
            forcedOBJRB.mass = mass;
            UIManager._Instance.UpdateMassTxt();
        }
    }
    public float GetVelocity => forcedOBJRB.velocity.magnitude;
    public void UpdateFrictions(bool isStaticFriction, float amount) {
        if (isStaticFriction && objPMat.staticFriction != amount)
        {
            UIManager._Instance.UpdateFrictionTxt(isStaticFriction);
            objPMat.staticFriction = amount;
        }
        else if (!isStaticFriction && objPMat.dynamicFriction != amount)
        {

            objPMat.dynamicFriction = amount;
            UIManager._Instance.UpdateFrictionTxt(!isStaticFriction);
        }
    }
}
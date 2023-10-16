using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftDriving : MonoBehaviour
{
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private GameObject powerEngine;
    [SerializeField] private GameObject CM;
    [SerializeField] private float Gas;
    [SerializeField] private float Turn;
    private float horizontalInput;
    private float verticalInput;
    void Start()
    {
        //carRigidbody.centerOfMass = CM.transform.localPosition;
    }


    void Update()
    {
        //carRigidbody.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * Gas, powerEngine.transform.position);
        //carRigidbody.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * Turn);
        //carRigidbody.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(carRigidbody.velocity).x * 5f);
        carRigidbody.AddForce(transform.TransformDirection(Vector3.forward) * Time.deltaTime * Gas * Input.GetAxis("Vertical"));
        carRigidbody.AddTorque(transform.TransformDirection(Vector3.up) * Time.deltaTime * Turn * Input.GetAxis("Horizontal"));
    }

}



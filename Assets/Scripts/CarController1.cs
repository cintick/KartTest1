using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController1 : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    [SerializeField] private List<GameObject> springs;
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private GameObject powerEngine;
    [SerializeField] private GameObject CM;
    [SerializeField] private float Gas;
    [SerializeField] private float Turn;

    void Start()
    {
        carRigidbody.centerOfMass = CM.transform.localPosition;
        Debug.Log(CM.transform.position);
        Debug.Log(carRigidbody.centerOfMass);
    }

    void Update()
    {
        carRigidbody.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * Gas, powerEngine.transform.position);
        carRigidbody.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * Turn);
        foreach (GameObject spring in springs)
        {
            RaycastHit hit;
            if (Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
            {
                Debug.Log("SpringHitGround");
                carRigidbody.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * 10000f, spring.transform.position);
            }
            Debug.Log(hit.distance);
        }
        carRigidbody.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(carRigidbody.velocity).x * 5f);
    }

}
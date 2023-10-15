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
    }

    void Update()
    {
        GetInput();
        carRigidbody.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * verticalInput * Gas, powerEngine.transform.position);
        carRigidbody.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * horizontalInput * Turn);
        foreach (GameObject spring in springs)
        {
            RaycastHit hit;
            if (Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                carRigidbody.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2)/3f * 250f, spring.transform.position);
            }
            Debug.Log(hit.distance);
        }
        carRigidbody.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(carRigidbody.velocity).x * 5f);
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

}
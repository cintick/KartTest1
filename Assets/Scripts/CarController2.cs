using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour {

    // Settings
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;
    //public float MoveVectorCorrection;

    // Variables
    private Vector3 MoveForce;

    // Update is called once per frame
    void Update() {

        // Moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
        // ESKI HALI transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 100);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
        //MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveVectorCorrection;

        //DENENECEKLER:
        //  1- Arabayý daha aðýr hissettirmek için steer input lag ? tarzý bir þey
        //  2- Arabanýn hýzýna göre steer angle'ýn azalmasý

        //MoveForce ESKI HALI
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cubePrefab;

    [SerializeField]
    private Transform explosionPosition;

    private bool isGravityRevered = false;
    private float gravityYValue = -9.8f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateCube();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isGravityRevered = !isGravityRevered;
            InvertGravity();
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("F pressed");
            ApplyExplosiveForceToAllCubes();
        }
    }

    void InstantiateCube()
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.parent = this.transform;
        Rigidbody cubeRigBody = cube.GetComponent<Rigidbody>();
        cubeRigBody.mass = Random.Range(20, 40);
        cubeRigBody.drag = Random.Range(1, 3);
        cubeRigBody.AddForce(Vector3.down * 300, ForceMode.Impulse);
    }

    void InvertGravity()
    {
        if (isGravityRevered)
        {
            gravityYValue = 9.8f;
        }
        else
        {
            gravityYValue = -9.8f;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, gravityYValue, Physics.gravity.z);
    }

    void ApplyExplosiveForceToAllCubes()
    {
        Rigidbody[] allCubes = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody cube in allCubes)
        {
            Rigidbody rigidBody = cube.GetComponent<Rigidbody>();
            rigidBody.AddExplosionForce(2000f, explosionPosition.position, 100f, 100f, ForceMode.Impulse);
        }
    }

}

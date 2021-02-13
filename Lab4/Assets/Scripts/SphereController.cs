using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour, InteractiveObjectBase
{

    [SerializeField]
    GameObject explosion;

    [SerializeField]
    float explosionRadius = 250f;

    [SerializeField]
    float explosionUpwardsModifier = 0.1f;

    [SerializeField]
    float explosionMagnitude = 1000f;

    void start()
    {

    }

    public void OnInteraction(bool shouldChangeColour = false)
    {
        TriggerExplosion();
    }

    void TriggerExplosion()
    {
        // Instantiate an explosion prefab at collider transform

        GameObject empty = new GameObject();
        empty.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1000f, LayerMask.GetMask("Explosion"));

        Instantiate(explosion, empty.transform);

        for(int index = 0; index < colliders.Length; index++)
        {
            float xForce = Random.Range(0, 20);
            float yForce = Random.Range(0, 30);
            float zForce = Random.Range(0, 20);
            colliders[index].GetComponent<Rigidbody>().AddForce(new Vector3(xForce, yForce, zForce), ForceMode.Impulse);
        }
    }

    void PlayExplosionNoise()
    {

    }
}

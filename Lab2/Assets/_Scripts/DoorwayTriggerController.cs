using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayTriggerController : MonoBehaviour
{
    private AudioSource doorwaySound;

    void Start()
    {
        doorwaySound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(PlayDoorWaySound());
            StopCoroutine(PlayDoorWaySound());
        }
    }

    IEnumerator PlayDoorWaySound()
    {
        doorwaySound.Play();
        yield return new WaitForSeconds(3);
    }
}

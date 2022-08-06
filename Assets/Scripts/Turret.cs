using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform playerPosition;
    private bool detected = false;

    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPosition);
        DetectingPlayer();
    }

    private void DetectingPlayer()
    {
        float playerDistance = Vector3.Distance(playerPosition.transform.position, transform.position);

        if(playerDistance <= 15 && !detected)
        {
            detected = true;
            InvokeRepeating("Shooting", 0, 1);
        }
        else if(playerDistance > 15)
        {
            detected = false;
            CancelInvoke("Shooting");
        }
    }

    private void Shooting()
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}

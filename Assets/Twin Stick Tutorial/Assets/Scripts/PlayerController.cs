﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 50f;
    public GameObject bulletPrefab;
    public Transform launchPosition;
    public LayerMask layerMask;

    CharacterController characterController;

    public override void OnStartLocalPlayer()
    {
        CameraMovement cMove = Camera.main.transform.parent.GetComponent<CameraMovement>();
        cMove.followTarget = gameObject;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        pos.z += Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.position = pos;

        if (Input.GetButtonDown("Fire1"))
        {
            if (!IsInvoking("Shoot"))
            {
                InvokeRepeating("Shoot", 0f, 0.1f);
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shoot");
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {

        }
        Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    [CommandAttribute]
    void CmdShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
        NetworkServer.Spawn(bullet, bulletPrefab.GetComponent<NetworkIdentity>().assetId);
    }

    void Shoot()
    {
        CmdShoot();
    }
}

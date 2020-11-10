using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;
    public float firerate = 10.0f;
    public float impactForce = 100.0f;

    public GameObject gun1;
    public GameObject gun2;
    public Camera fpscamera;
    public VisualEffect muzzleflash;

    private float nexttime = 0.0f;
    private float dividefirerate = 0.0f;
    public bool isgun1 = false;
    private void Start()
    {
        muzzleflash.Stop();
        dividefirerate = 1.0f / firerate;
        gun1.SetActive(true);
        gun2.SetActive(false);
        isgun1 = true;
    }
    void Update()
    {
        if (Input.GetKey("1"))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            isgun1 = true;
        }
        else if(Input.GetKey("2"))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            isgun1 = false;
        }

        if (isgun1==false)
        {
            if (Input.GetButtonDown("Fire1") )
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nexttime)
            {
                nexttime = Time.time + dividefirerate;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;

        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
           // Debug.Log(hit.transform.name);
        }

        IDamageable target = hit.transform.GetComponent<IDamageable>();
        if(target!=null)
        {
            target.TakeDamage(damage);
        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(hit.normal * impactForce);
        }
    }

  
}

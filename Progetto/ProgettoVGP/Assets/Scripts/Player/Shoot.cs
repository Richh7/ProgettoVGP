using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shoot : MonoBehaviour
{

    public float raycastDistance = 13f;

    private Camera myCamera;
    private LineRenderer laser;


    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        laser = GetComponent<LineRenderer>();
        laser.SetPosition(0, myCamera.GetComponentInParent<Transform>().transform.position);
        laser.SetPosition(1, myCamera.GetComponentInParent<Transform>().transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            laser.enabled = true;
            laser.SetPosition(0, myCamera.GetComponentInParent<Transform>().transform.position - new Vector3(0, 0.4f, 0));

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, raycastDistance) && hit.rigidbody != null)
            {
                if (hit.rigidbody.gameObject.layer == 8)
                {
                    laser.SetPosition(1, hit.point);
                    CheckChild light = hit.rigidbody.gameObject.GetComponent<CheckChild>();
                    if (light.hasChild)
                    {
                        hit.rigidbody.gameObject.GetComponent<AudioSource>().Play();
                        FindObjectOfType<Game_Manager>().lightsToSetActive.Add(hit.rigidbody.gameObject);
                        FindObjectOfType<Game_Manager>().lightsToSetActive.Add(hit.rigidbody.gameObject.GetComponentInChildren<DamagePlayer>().gameObject);
                        hit.rigidbody.gameObject.GetComponentInChildren<DamagePlayer>().gameObject.SetActive(false);
                        light.SetChild(false);
                    }
                }
            } else
            {
                laser.SetPosition(1, ((Camera.main.transform.forward * raycastDistance) + myCamera.GetComponentInParent<Transform>().transform.position));
            }
        } else
        {
            laser.enabled = false;
        }
    }
}

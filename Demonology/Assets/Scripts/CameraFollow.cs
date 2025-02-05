﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

    //For Camera Zooming
	public float maxZoomOut;
	public float maxZoomIn;
    public int zoomSpeedMouse = 20;
    public int zoomSpeedKeys = 4;
    public float downZoomDistance = 1;
	// Update is called once per frame
	void Update () 
	{
        // Check to see if player exists i.e not dead
		if (DeadlyBehavior.Player)
		{
			//For Zooming with ScrollWheel
			if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
			{
                //Zoom In
				if(transform.position.z<-(maxZoomIn))
				{
                    Zoom(zoomSpeedMouse);
				}
			}
            else if (Input.GetAxis("ScrollKeys") > 0) 
            {
                if (transform.position.z < -(maxZoomIn))
                {
                    Zoom(zoomSpeedKeys);
                }
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                //Zoom Out
                if (transform.position.z > -(maxZoomOut))
                {
                    Zoom(-zoomSpeedMouse);
                }
            }
            else if (Input.GetAxis("ScrollKeys") < 0)
            {
                if (transform.position.z > -(maxZoomOut))
                {
                    Zoom(-zoomSpeedKeys);
                }
            }

            else if (Input.GetKey(KeyManagerScript.keys["LookDown"])) 
            {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(DeadlyBehavior.Player.transform.position);
                Vector3 delta = DeadlyBehavior.Player.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, downZoomDistance, point.z)); //(new Vector3(0.5, 0.5, point.z));
                CamDampMove(delta);
            }
            else
            {
                //Camera Move with player movement
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(DeadlyBehavior.Player.transform.position);
                Vector3 delta = DeadlyBehavior.Player.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.35f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                CamDampMove(delta);
            }
		}
		
	}



    //Dampened Camera Movement
    void CamDampMove(Vector3 delta) 
    {
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }

    //Zooming In and Out
    void Zoom(int Zchange) 
    {
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(DeadlyBehavior.Player.transform.position);
        Vector3 delta = new Vector3(DeadlyBehavior.Player.transform.position.x, DeadlyBehavior.Player.transform.position.y, DeadlyBehavior.Player.transform.position.z + Zchange) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.35f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        CamDampMove(delta);
    }
}
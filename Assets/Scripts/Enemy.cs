using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 1f;
	public float minDist = 0.1f;
	public Transform arCamera;
	private bool startMoving;

	public ParticleSystem blastParticleEffect;

	AudioSource dieSound;

	void Start()
	{
		//if no camera, assume the camera
		if (arCamera == null)
		{
			if (GameObject.FindWithTag("MainCamera") != null)
			{
				arCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
			}
		}
		transform.LookAt(arCamera);
		startMoving = false;
		dieSound = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(gameObject.transform.position.y < -3f)
        {
			Destroy(gameObject, 0.2f);
			return;
        }

		if (arCamera == null)
			return;

        if (startMoving)
        {
			//look at player
			transform.LookAt(arCamera);

			//distance between the enemy and the player
			float distance = Vector3.Distance(transform.position, arCamera.position);

			//if(distance > minDist)	
			transform.position += transform.forward * speed * Time.deltaTime;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "MainCamera")
		{
			Destroy(gameObject);
			startMoving = false;
			dieSound.Play();

			Vector3 particlePos = transform.position;
			if(blastParticleEffect != null)
            {
				Instantiate(blastParticleEffect, particlePos, Quaternion.identity);
            }
		}

		if(other.gameObject.tag == "Plane")
        {
			startMoving = true;
        }
	}
}
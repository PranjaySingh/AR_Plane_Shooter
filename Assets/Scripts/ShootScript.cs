using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public TextMeshProUGUI scoreText;
    //public Text scoreText;
    public ParticleSystem blastParticleEffect;

    AudioSource audioSource;


    int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        RaycastHit hit;
        audioSource.Play();

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                score++;
                scoreText.text = score.ToString();
                
                Destroy(hit.transform.gameObject, 0.15f);
                Vector3 particlePos = hit.transform.position;
                if (blastParticleEffect != null)
                {
                    Instantiate(blastParticleEffect, particlePos, Quaternion.identity);
                }
            }
        }
    }
}

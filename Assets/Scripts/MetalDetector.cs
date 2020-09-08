using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class MetalDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip beepSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float soundFrequency;
    [SerializeField] private float timer;
    [SerializeField] private Transform closestMine;
    [SerializeField] private List<GameObject> mines;
    void Start()
    {
        
        timer = Time.time;
        mines = GameObject.FindGameObjectsWithTag("Mine").ToList();
        closestMine = GetClosestMine(mines);
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetManager().GetMinesLeft() > 0)
        {
            if (closestMine == null)
            {
                mines = GameObject.FindGameObjectsWithTag("Mine").ToList();
            }

            closestMine = GetClosestMine(mines);

            float dist = (closestMine.position - transform.position).magnitude;
            soundFrequency = dist / 20;
            MakeSound();
        }
        else
        {
            mines.Clear();
        }
    }

    Transform GetClosestMine(List<GameObject> mines)
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currPos = transform.position;
        foreach (GameObject t in mines)
        {
            float dist = (t.transform.position - currPos).magnitude;
            if (dist <= minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        if (closest != null)
        {
            return closest.transform;
        }

        return null;
    }

    void MakeSound()
    {
        if (Time.time >= timer + soundFrequency)
        {
            audioSource.PlayOneShot(beepSound, audioSource.volume);
            timer = Time.time;
        }
    }
}

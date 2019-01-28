﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public bool bossActive;

    public float timeBetweenDrop;
    public float timeBetweenDropInitial;
    public float dropCount;
    public float waitForPlatform;
    public float platformCount;

    public Transform rightPoint;
    public Transform leftPoint;
    public Transform spinSawRespawnPoint;

    public GameObject fallingSpinSaw;
    public GameObject boss;
    public GameObject rightPlatform;
    public GameObject leftPlatform;

    public GameObject levelExit;
    public GameObject winningPlatform;

    public bool bossRight;
    public bool takeDamage;

    public int bossHealth;
    public int currentHealth;



    public bool waitForRespawn;

    


    void Start () {
        bossRight = true;
        dropCount = timeBetweenDrop;
        timeBetweenDropInitial = timeBetweenDrop;
        platformCount = waitForPlatform;
        boss.transform.position = rightPoint.position;
        currentHealth = bossHealth;
        
	}
	
	
	void Update () {
        //if (FindObjectOfType<GameSession>().respawnCoActive)
        //{
        //    boss.SetActive(false);
        //    waitForRespawn = true;
        //}
        if (waitForRespawn)
        {
            
            waitForRespawn = false;

            //Platform
            leftPlatform.SetActive(false);
            rightPlatform.SetActive(false);
            platformCount = waitForPlatform;

            //Drop
            dropCount = timeBetweenDropInitial;

            //Boss
            boss.SetActive(false);
            bossActive = false;
            //boss.transform.position = rightPoint.position;
            bossRight = true;
            currentHealth = bossHealth;


            
        }


        if (bossActive)
        {                      
            if (bossRight)
            {
                if (platformCount>0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    rightPlatform.SetActive(true);
                }
            }
            else
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    leftPlatform.SetActive(true);
                }
            }

            if (takeDamage)
            {
                currentHealth -= 1;
                if (bossRight)
                {
                    boss.transform.position = leftPoint.position;
                }
                else
                {
                    boss.transform.position = rightPoint.position;
                }
                bossRight = !bossRight;
                leftPlatform.SetActive(false);
                rightPlatform.SetActive(false);
                platformCount = waitForPlatform;

                timeBetweenDrop /= 2f;
                takeDamage = false;

                if (currentHealth<=0)
                {
                    levelExit.SetActive(true);
                    winningPlatform.SetActive(true);
                    gameObject.SetActive(false); //make the boss invisible
                   
                }
            }


            boss.SetActive(true);
            if (dropCount>0)
            {
                dropCount -= Time.deltaTime;
            }
            else
            {
                spinSawRespawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), spinSawRespawnPoint.position.y, spinSawRespawnPoint.position.z);
                Instantiate(fallingSpinSaw, spinSawRespawnPoint.position, spinSawRespawnPoint.rotation);
                dropCount = timeBetweenDrop;
            }
        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            bossActive = true;
        }
    }
}

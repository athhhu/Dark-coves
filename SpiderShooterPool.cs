using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject spiderBullet;

    private List<GameObject> bullets= new List<GameObject>();

    [SerializeField]
    private Transform bullettSpawnPos;

    [SerializeField]
    private int initialBullets = 8;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;



//------------------ALL THE FUNCTI0N BELOW ------------------------------
    private void Awake()
    {
        CreateInitialBullets();
    }

    private void Start()
    {
        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }
    private void Update()
    {
        if (Time.time> waitTime) 
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }
    void CreateInitialBullets()
    {
        for (int i = 0; i < initialBullets; i++)
        {
            GameObject newBullets = Instantiate(spiderBullet);
            newBullets.SetActive(false);
            newBullets.transform.SetParent(transform);
            bullets.Add(newBullets);
        }
    }    
    
    void Shoot() 
    {
        for(int i = 0; i < bullets.Count; i++) 
        {
            if (!bullets[i].activeInHierarchy) 
            {
                bullets[i].SetActive(true);
                bullets[i].transform.position = bullettSpawnPos.position;
                break;
            }
         
        }
    }




}



















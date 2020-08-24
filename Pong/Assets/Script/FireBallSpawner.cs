using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    [SerializeField] private float delaySpawn;
    public float defaultDelay;
    public GameObject fireBall;
    public static bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        delaySpawn = defaultDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawned)
        {
            delaySpawn -= Time.deltaTime;
            if(delaySpawn < 0)
            {
                isSpawned = true;
                delaySpawn = defaultDelay;
                Instantiate(fireBall, Vector3.zero, Quaternion.identity);
            }
        }
    }
}

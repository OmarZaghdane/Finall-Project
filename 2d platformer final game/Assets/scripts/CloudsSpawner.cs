using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public GameObject CloudPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnClouds", 10f, 30f);
    }

    void SpawnClouds()
    {
        var go = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        Destroy(go, 40);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] highClouds;
    public GameObject[] lowClouds;
    public int noOfClouds = 100;
    public float[] bounds = {200, 200, 200}; // X, Y, Z
    public Transform windDirection;
    public bool randomWindDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        if(randomWindDirection)
        {
            // randomly pick a wind direction
            Vector3 euler = transform.eulerAngles;
            euler.y = Random.Range(0f, 360f);
            euler.x = 0f;
            euler.z = 0f;
            windDirection.eulerAngles = euler;
        }

        GenerateClouds();
    }

    //TODO: Improve cloud repositioning to avoid popping in/out clouds
    void Update() 
    {
        GameObject [] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        foreach (var cloud in clouds)
        {
            Vector3 cloudPosition = cloud.transform.position;
            if (cloudPosition.x > bounds[0] || cloudPosition.x < -bounds[0])
            {
                cloudPosition.x = cloudPosition.x < -bounds[1] ? cloudPosition.x + bounds[0] * 2 : cloudPosition.x - bounds[0] * 2;
                cloud.transform.position = cloudPosition;
            }
            else if (cloudPosition.z > bounds[2] || cloudPosition.z < -bounds[2])
            {
                cloudPosition.z = cloudPosition.z < -bounds[2] ? cloudPosition.z + bounds[2] * 2 : cloudPosition.z - bounds[2] * 2;
                cloud.transform.position = cloudPosition;
            }
        }
    }

    void GenerateClouds()
    {
        for (int i = 0; i < noOfClouds; i++)
        {
            bool isLowCloud = i < noOfClouds / 2;
            int randomInt = isLowCloud ? Random.Range(0, lowClouds.Length) : Random.Range(0, highClouds.Length);
            //Debug.Log(randomInt);
            float minHeight = isLowCloud ? bounds[1]/2 : (bounds[1]/4 + bounds[1]/2);
            float maxHeight = isLowCloud ? (bounds[1]/4 + bounds[1]/2) : bounds[1];
            GameObject cloud = isLowCloud ? lowClouds[randomInt] : highClouds[randomInt];
            GenerateCloud(cloud, maxHeight, minHeight);
        }
    }

    void GenerateCloud(GameObject cloud, float maxHeight, float minHeight)
    {
        float randomY = Random.Range(minHeight, maxHeight);
        float randomX = Random.Range(-bounds[0], bounds[0]);
        float randomZ = Random.Range(-bounds[2], bounds[2]);

        Instantiate(cloud, new Vector3(randomX, randomY, randomZ), windDirection.rotation);
    }
}

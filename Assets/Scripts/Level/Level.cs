using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<ObstaclePH> obstaclePHs;
    [SerializeField] List<CollectiblePH> collectiblePHs;
    List<PoolObject> levelObjects;

    [Header("Road")]
    [SerializeField] Vector3 roadStartingPos;
    [SerializeField] float roadOffset;
    [SerializeField] List<float> roadYPoses;
    public void Initialize()
    {
        levelObjects = new List<PoolObject>();
    }

    public void OnActive()
    {
        generateRoad();
        putObjects();
    }

    public void OnDisactive()
    {
        foreach(var item in levelObjects)
        {
            item.Dismiss();
        }
    }

    private void generateRoad()
    {
        Vector3 roadPos = roadStartingPos;
        for (int i = 0; i < roadYPoses.Count; i++)
        {
            PoolObject road = PoolManager.Instance.GetItem("Road");
            roadPos.y = roadYPoses[i];
            road.SetActiveWithPosition(roadPos);
            roadPos += new Vector3(0, 0, roadOffset);
            levelObjects.Add(road);
        }

        PoolObject finisher = PoolManager.Instance.GetItem("Finisher");
        finisher.SetActiveWithPosition(roadPos);
        levelObjects.Add(finisher);
    }

    private void putObjects()
    {
        foreach (ObstaclePH item in obstaclePHs)
        {
            Obstacle obstacle = PoolManager.Instance.GetItem(item.obstacleType.ToString()) as Obstacle;
            obstacle.SetActiveWithPosition(item.transform.position);
            levelObjects.Add(obstacle);
        }
        foreach (CollectiblePH item in collectiblePHs)
        {
            Collectible collectible = PoolManager.Instance.GetItem(item.collectibleType.ToString()) as Collectible;
            if(collectible is Coin)
            {
                collectible.GetComponent<Coin>().Value = item.Value;
            }
            collectible.SetActiveWithPosition(item.transform.position);
            levelObjects.Add(collectible);
        }
    }
}


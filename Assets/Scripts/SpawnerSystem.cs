using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i<BootStrapper.Settings.Count; i++)
            {
                var newPosition = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
                var instance = Object.Instantiate(BootStrapper.Settings.SkeletonPrefab, newPosition, Quaternion.identity);
            }
        }
    }
}

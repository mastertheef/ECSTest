using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;
using Unity.Transforms;

public class SkeletonMoveSystem : ComponentSystem {
    public struct Data
    {
        public int Length;
        public ComponentArray<NavMeshAgent> navMesh;
        public ComponentArray<Animator> anim;
    }

    public struct TargetData
    {
        public ComponentDataArray<TargetComponent> Target;
        public ComponentArray<Transform> transform;
    }

    [Inject] Data data;
    [Inject] TargetData targetData;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data.anim[i].SetBool("IsRunning", true);
            
            data.navMesh[i].SetDestination(targetData.transform[0].position);


            if (data.navMesh[0].remainingDistance <= 20)
            {
                data.anim[i].SetBool("IsRunninig", false);
                data.navMesh[0].isStopped = true;
            }
        }
    }
}

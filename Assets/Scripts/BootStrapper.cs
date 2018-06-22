using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class BootStrapper : MonoBehaviour {

    public GameObject Target;
    public static Settings Settings;

	// Use this for initialization
	void Start () {
        
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var targetEntity = Target.GetComponent<GameObjectEntity>().Entity;
        entityManager.AddComponentData(targetEntity, new TargetComponent());
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeWithScene()
    {
        var settingsGo = GameObject.Find("Settings");
        Settings = settingsGo?.GetComponent<Settings>();
    }
}

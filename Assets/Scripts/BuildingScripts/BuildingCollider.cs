using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingCollider : MonoBehaviour
{
    private GameObject _parent;
    private RootBuildingCollider _rootBuildingColliderScript;
    // Use this for initialization
    void Start()
    {
        _parent = gameObject.transform.root.gameObject;
        _rootBuildingColliderScript = _parent.GetComponent<RootBuildingCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerStay(Collider other)
    {
         UpdateBuildingColliders(gameObject.name, true, other);
    }

    public void OnTriggerEnter(Collider other)
    {
         UpdateBuildingColliders(gameObject.name, true, other);
    }

    public void OnTriggerExit(Collider other)
    {
         UpdateBuildingColliders(gameObject.name, false, other);
    }

    private void UpdateBuildingColliders(string name, bool isCollided, Collider other)
    {
        if (_parent.transform.root.gameObject.GetInstanceID() != other.transform.root.gameObject.GetInstanceID())
        {
            if (!_rootBuildingColliderScript.BuildingColliders.ContainsKey(name))
                _rootBuildingColliderScript.BuildingColliders.Add(name, isCollided);
            else
                _rootBuildingColliderScript.BuildingColliders[name] = isCollided;
        }
    }
}

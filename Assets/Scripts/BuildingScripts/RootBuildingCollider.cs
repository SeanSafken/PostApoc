using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RootBuildingCollider : MonoBehaviour {

    public Dictionary<string, bool> BuildingColliders;
    public bool IsValidLocation = false;

    public int NumberOfSupports = 4;

	// Use this for initialization
	void Start () {
        BuildingColliders = new Dictionary<string, bool>();
    }
	
	// Update is called once per frame
	void Update () {
        IsValidLocation = (CheckWalls() && CheckSupports());
	}

    private bool CheckWalls()
    {
        bool isValid = false;

        var walls = (from b in BuildingColliders
                     where b.Key.Contains("Wall")
                     && b.Value == true
                     select b).ToList();

        isValid = (!walls.Any());
        
        return isValid;
    }

    private bool CheckSupports()
    {
        bool isValid = false;

        var buildingColliders =
            (from b in BuildingColliders
             where b.Key.Contains("Support")
             && b.Value == true
             select b).ToList();

        //check supports
        isValid = (buildingColliders.Count() == NumberOfSupports);

        return isValid;
    }

}

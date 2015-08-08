using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

    private Camera camera;

    private bool _instantiated = false;

    private bool _setupContruction = false;
    private bool _placeObject = false;

    public LayerMask BuildLayerMask;

    private Transform _building;
    private Transform _beingBuilt;

    RaycastHit hit;
    Ray ray;

    private GameObject fps;
    private bool _placed = false;

    private RootBuildingCollider _rootBuildingColliderScript;

    private string GuiMessage = "";

    // Use this for initialization
    void Start () {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.B))
        {
            _setupContruction = true;
        }

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (_setupContruction && Physics.Raycast(ray, out hit, 50, BuildLayerMask))
        {
            if (hit.transform.tag == "terrain")
            {
                Vector3 buildLoc = new Vector3(hit.point.x, hit.point.y + 1.17f, hit.point.z);
                if (!_instantiated)
                {
                    _beingBuilt = Instantiate(Resources.Load("TownCenter",typeof(Transform)), buildLoc, Quaternion.identity) as Transform;
                    _instantiated = true;
                }
                if (_instantiated) {

                    if (_rootBuildingColliderScript == null)
                        _rootBuildingColliderScript = _beingBuilt.GetComponent<RootBuildingCollider>();

                    //move to crosshair location
                    _beingBuilt.transform.localPosition = buildLoc;

                    //rotate object
                    if (Input.GetKey(KeyCode.Q))
                        _beingBuilt.transform.RotateAround(buildLoc, Vector3.up, -50.0f * Time.deltaTime);

                    if (Input.GetKey(KeyCode.E))
                        _beingBuilt.transform.RotateAround(buildLoc, Vector3.up, 50.0f * Time.deltaTime);
                }
            }
        }

        //place building and reset
        if(_setupContruction && _rootBuildingColliderScript != null)
        {
            
            if (_rootBuildingColliderScript.IsValidLocation)//building in valid location
            {
                GuiMessage = "Valid";

                if (Input.GetButtonDown("Fire"))
                {
                    _setupContruction = false;
                    _instantiated = false;
                    _beingBuilt = null;
                    _rootBuildingColliderScript = null;

                    GuiMessage = "";
                }
            }
            else
            {

                GuiMessage = "Invalid";
            }
        }
        
    }

    void FixedUpdate()
    {
        
    }

    void OnGUI ()
    {
        GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 50), "><");
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 50, 100, 50), GuiMessage);
    }
}

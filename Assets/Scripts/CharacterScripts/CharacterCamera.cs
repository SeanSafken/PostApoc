using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour {

    public Transform Player;
    Vector3 offset;
    public float smoothing = 5f;

    // Use this for initialization
    void Start () {
        offset = transform.position - Player.position;
    }
	
	// Update is called once per frame
	void Update () {


        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = Player.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

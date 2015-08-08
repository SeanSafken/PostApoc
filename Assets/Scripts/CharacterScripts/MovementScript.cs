using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MovementScript : MonoBehaviour {

    Animator _playerAnimator;
	// Use this for initialization
	void Start () {
        _playerAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        _playerAnimator.SetFloat("Walk",vertical);
    }
}

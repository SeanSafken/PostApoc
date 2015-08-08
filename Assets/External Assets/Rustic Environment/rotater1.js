var ySpeed : float = 1;

function Update() {
		// Slowly rotate the object around its X axis at 1 degree/second.
		transform.Rotate(Vector3.up, ySpeed * Time.deltaTime);

	}

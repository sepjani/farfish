using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour
{

	public Transform Player;
	public BoxCollider2D LevelBounds;
	public Vector2 Margin;
	public float sensetive = 10;
	private Vector3 minVector;
	private Vector3 maxVector;
	Camera camera;
	private Vector3 m_CurrentVelocity;
	public bool IsFollowing { get; set; }

	void Start ()
	{
		camera = GetComponent<Camera> ();
		minVector = LevelBounds.bounds.min;
		maxVector = LevelBounds.bounds.max;
		IsFollowing = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var x = transform.position.x;
		var y = transform.position.y;


		if (IsFollowing) {
			Vector3 plPos = Player.position;
			plPos = new Vector3 (plPos.x + 3, plPos.y - 6, plPos.z);
			if (Mathf.Abs (x - plPos.x) > Margin.x) {
				x = Mathf.Lerp (x, plPos.x, 15 * Time.deltaTime);		
			}
			if (Mathf.Abs (y - plPos.y) > Margin.y) {
				y = Mathf.Lerp (y, plPos.y, 15 * Time.deltaTime);		
			}
		}


		float screenRatio = Screen.width / Screen.height;
		var cameraWidth = camera.orthographicSize * screenRatio;
		x = Mathf.Clamp (x, minVector.x + cameraWidth, maxVector.x - cameraWidth);
		y = Mathf.Clamp (y, minVector.y + camera.orthographicSize, maxVector.y - camera.orthographicSize);
		Vector3 newPosition = new Vector3 (x, y, transform.position.z);

		transform.position = Vector3.SmoothDamp (transform.position, newPosition, ref m_CurrentVelocity, Time.deltaTime * sensetive);
	}
}

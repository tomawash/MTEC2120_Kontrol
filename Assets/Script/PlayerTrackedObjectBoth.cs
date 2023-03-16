using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using OpenCvSharp.Demo;
public class PlayerTrackedObjectBoth : MonoBehaviour
{

	public TrackingScript trackedObj;
	public RawImage rawImage;
	public float scaleX;
	public float scaleY;

	public float offSetX;
	public float offSetY; 

	bool dead;
	//public AudioClip[] auClip;
	public GameObject fire;

	float lastY = 0;
	float lastX = 0;

	public float xMax = 7f;
	public float yMax = 4.5f;

	void Start()
	{
		dead = false;
		//GetComponent<AudioSource>().clip = auClip[0];

		//transform.position = new Vector3(0, 0, 0);
	}

	void Update()
	{

		Vector2 pos2D = trackedObj.GetImageCoord();
		
		Vector2 output = new Vector2();
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImage.rectTransform, pos2D, Camera.main, out output);


		float x = output.x*scaleX - offSetX;
		float y = output.y*scaleY - offSetY;
		//Debug.Log("Player Update : " + x + " " + y);


		float normY = 3 * Mathf.Clamp(output.y - lastY, -1, 1);
		float normX = 3 * Mathf.Clamp(output.x - lastX, -1, 1);
		transform.position = new Vector3(x, y, 0);
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - normX, transform.position.y - normY, transform.position.z), 0.1f);
		
		if(transform.position.x > Mathf.Abs(xMax) || transform.position.x < Mathf.Abs(xMax) * -1)
        {
			transform.position = new Vector3( xMax * Mathf.Sign(transform.position.x), transform.position.y, 0);
        }

		if (transform.position.y > Mathf.Abs(yMax) || transform.position.y < Mathf.Abs(yMax) * -1)
		{
			transform.position = new Vector3(transform.position.x, yMax * Mathf.Sign(transform.position.y), 0);
		}

		lastY = output.y;
		lastX = output.x;


		//if (Input. GetMouseButtonDown(0) && !dead)
		//{
		//	RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		//	if (hit.collider == null)
		//	{
		//		Jump();
		//	}
		//}
	}

	//void Jump()
	//{
	//	fire.SetActive(true);
	//	GetComponent<AudioSource>().Play();
	//	GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	//	GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
	//}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!dead)
		{
			if (col.tag == "Score")
			{
				GameObject.FindObjectOfType<GameManager>().Score++;
				Destroy(col.gameObject);
			}
			else if (col.tag == "Finish")
			{
				//dead = true;
				GameObject.FindObjectOfType<GameManager>().Score--;
				//GetComponent<AudioSource>().clip = auClip[1];
				//GetComponent<AudioSource>().Play();
				Invoke("BackToMain", 1.5f);
			}
		}
	}

	void BackToMain()
	{

        trackedObj.Disable();

        SceneManager.LoadScene("MainMenu");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePod : MonoBehaviour {
	[Header("SpaceOdd")]
	[Range(0, 10)]
	public float speed = 1f;
	[Range(0, 360)]
	public float rotateSpeed;
	public bool _isCrash = false;

	// store reference to resource
	public AudioClip impact;

	// set reference to script
	private CameraShake shaker;

	// player tracking
	bool _isThrust = false;

	// store reference to components on the gameObject
	AudioSource _audioSource;
	Animator _animator;
	Rigidbody2D rb;

	void Awake (){
		rb = GetComponent<Rigidbody2D>();
		if (rb == null) // if Rigidbody is missing
			Debug.LogError("Rigidbody2D component is missing from SpacePod");

		_animator = GetComponent<Animator>();
		if (_animator == null) // if Animator is missing
			Debug.LogError("Animator component is missing from SpacePod");

		_audioSource = GetComponent<AudioSource>();
		if (_animator == null) // if Animator is missing
			Debug.LogError("AudioSource component is missing from SpacePod");

		shaker = GameObject.FindObjectOfType<CameraShake>();

	}

	// Use this for initialization
	void Start () {
	}

	public void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Edge") {
			shaker.Shake(.2f, .3f);
		}

	}

	void Update() {
		// set thrust animation state
		_animator.SetBool("Thrust", _isThrust);
	}

	void FixedUpdate ()
	{
		if (GameManager.gm.gameStart) {
			Move();
		}
	}

	void Move ()
	{
		// space pod thrust
		//float x = Input.GetAxis ("Vertical"); 
		if (Input.GetKey (KeyCode.Space)) {
			//rb.AddForce(transform.up * speed * Mathf.Clamp(x, 0, 1));
			rb.AddForce (transform.up * speed);
			if (!_audioSource.isPlaying) {
				_audioSource.PlayOneShot (impact);
			}
			_isThrust = true;
		} else {
			rb.velocity *= .99f;
			_audioSource.Stop ();
			_isThrust = false;
		}

		// space pod rotete
		float y = Input.GetAxis ("Horizontal");
		if (y != 0) {
			rb.MoveRotation (rb.rotation - rotateSpeed * Time.fixedDeltaTime * y);
		}
	}

}

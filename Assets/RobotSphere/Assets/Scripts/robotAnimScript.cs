using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class robotAnimScript : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] float walkSpeed = 2f;
	[SerializeField] float rotSpeed = 40f;
    [SerializeField] float jumpSpeed = 50f;
    [Space]
    [Header("Robot")]
    [SerializeField] float health = 100f;

	Vector3 rot = Vector3.zero;
	Animator anim;

	// Use this for initialization
	void Awake () {
		anim = gameObject.GetComponent<Animator> ();
		gameObject.transform.eulerAngles = rot;
	}
	
	// Update is called once per frame
	void Update () {
		CheckKey ();
        checkDestroy();
		gameObject.transform.eulerAngles = rot;
	}

    void checkDestroy() {
        if (health <= 0) Destroy(gameObject);
    }

	void CheckKey(){
		// Walk
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("Walk_Anim", true);
            gameObject.transform.position += transform.forward * walkSpeed * Time.deltaTime;
		} 
		else if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetBool ("Walk_Anim", false);
		}

		// Rotate Left
		if(Input.GetKey(KeyCode.A)){
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if(Input.GetKey(KeyCode.D)){
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown (KeyCode.Space)) {
			//if (anim.GetBool ("Roll_Anim")) {
				anim.SetBool ("Roll_Anim", true);
            transform.position += transform.up * Time.deltaTime * jumpSpeed;
			//}
			//else {
				//anim.SetBool ("Roll_Anim", true);
			//}
		} 
        if(Input.GetKeyUp(KeyCode.Space))
            anim.SetBool("Roll_Anim", false);



        // Close
        if (Input.GetKeyDown(KeyCode.LeftControl)){
			if (!anim.GetBool ("Open_Anim")) {
				anim.SetBool ("Open_Anim", true);
			} 
			else {
				anim.SetBool ("Open_Anim", false);
			}
		}
	}

    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator PlayerAnim;
    public GameObject BombBallPrefab;
    public Transform FirePlace;
    public Rigidbody bombRb;

    public float playerSpeed = 5f;
    public float rotationSpeed = 200f;
    public int bombCount;

    public bool hasMultiBomb = false;
    // Start is called before the first frame updatew
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        bombCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        PlayerAnim.SetFloat("Speed" , verticalInput);


        transform.Translate(Vector3.forward * playerSpeed  * verticalInput * Time.deltaTime);

        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);


        bombCount = GameObject.FindGameObjectsWithTag("Bomb").Length;

        if(Input.GetKeyDown(KeyCode.Space) && bombCount==0)
        {
            if(hasMultiBomb == true)
            {
                Fire();
                Fire();
            }

            else
            {
                Fire();
            }
            
        }
    }

    
    void Fire()
    {
        GameObject Bomb = Instantiate(BombBallPrefab , FirePlace.position , FirePlace.rotation);
        Rigidbody rb = Bomb.GetComponent<Rigidbody>();
        rb.AddForce(FirePlace.forward * 5 , ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MultiBomb"))   //gameObject word is extra added, remove if cause problems
        {
            Debug.Log("Enter trigger");

            hasMultiBomb = true;
            Destroy(other.gameObject);
            StartCoroutine(MultiBombCountdownRoutine());

        }
    }

    IEnumerator MultiBombCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasMultiBomb = false;  
    }
    
    
}

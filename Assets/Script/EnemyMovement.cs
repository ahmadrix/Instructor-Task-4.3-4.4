using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject Player;
    public GameObject BombBallPrefab;
    public Transform FirePlace;
    public float enemySpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        InvokeRepeating("Fire" , 2 , 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.Find("Player") != null)
        {
            transform.LookAt(Player.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * 2); 
        }
        
        
           


        if(Input.GetKeyDown(KeyCode.P))
        {
            Destroy(gameObject);
        }

    }
    
    void Fire()
    {
        GameObject Bomb = Instantiate(BombBallPrefab , FirePlace.position , FirePlace.rotation);
        Rigidbody rb = Bomb.GetComponent<Rigidbody>();
        rb.AddForce(FirePlace.forward * 5 , ForceMode.Impulse);
        
        
    }
    

}

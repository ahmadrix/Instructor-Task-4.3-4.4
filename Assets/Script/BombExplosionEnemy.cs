using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionEnemy : MonoBehaviour
{
    public ParticleSystem bang;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBombCountdownRoutine());
    }

    IEnumerator DestroyBombCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        Instantiate(bang, transform.position, bang.transform.rotation);
        Destroy(GameObject.FindGameObjectWithTag("Enemy Bomb"));
        Destroy(GameObject.Find("Bomb Radius Enemy").GetComponent<BombRadiusEnemy>().player);
        
    }
}

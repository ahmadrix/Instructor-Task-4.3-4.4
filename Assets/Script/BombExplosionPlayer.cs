using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionPlayer : MonoBehaviour
{
    public ParticleSystem bang;
    // Start is called before the first frame update
    void Start()
    {
        bang.GetComponent<ParticleSystem>();
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
        Destroy(GameObject.FindGameObjectWithTag("Bomb"));
        Destroy(GameObject.Find("Bomb Radius").GetComponent<BombRadius>().enemy);  
    }
}

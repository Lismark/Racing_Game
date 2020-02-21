using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireing : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] float bulletLifeTime;
    private GameObject bulletObj;



    void Start()
    {

            
    }

    void Update()
    {
        Fire();
    }
    private void Fire()
    {
        Vector2 direction = firePoint.transform.position - gameObject.transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire!");
            bulletObj = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bulletObj.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(bulletDestroyer());
        }
    }

    public IEnumerator bulletDestroyer()
    {

        yield return new WaitForSeconds(bulletLifeTime); ;
        Destroy(bulletObj);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ProjectiltLaunch : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private float fireRate;
    [SerializeField] private Transform projectPos;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float bulletSpeed;
    private Vector3 versor;
    
    public float FireRate { get => fireRate; set => fireRate = value; }

    // Start is called before the first frame update
    void Start()
    {
        fireRate = timer;
    }

    // Update is called once per frame
    void Update()
    {
        shootAtPlayer();
    }

    public Vector3 getVersor()
    {
        return versor;
    }

    void shootAtPlayer()
    {
        timer = timer - Time.deltaTime;
        if (timer > 0)
        {
            return;
        }
        else
        {
            timer = fireRate;
            GameObject bullet = Instantiate(enemyBullet, projectPos.transform.position, projectPos.transform.rotation) as GameObject;
            Rigidbody bulletRig = bullet.GetComponent<Rigidbody>();
            versor = (target.transform.position - projectPos.transform.position);
            versor.Normalize();
            bulletRig.AddForce(versor * bulletSpeed);
            Destroy(bullet, 2f);

        }
        
    }
}

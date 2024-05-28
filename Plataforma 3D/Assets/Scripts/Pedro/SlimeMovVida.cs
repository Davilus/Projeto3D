using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMovVida : MonoBehaviour
{

    public Animator anim;
    public int enemyHealth = 1;
    int damage = 1;
    [SerializeField] AudioSource source;
    [SerializeField] NavMeshAgent Ari;

    public bool jump;
    public bool idle;
    public bool morte;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Andando", jump = false);
        anim.SetBool("Idle", idle = true);
        anim.SetBool("Morte", morte = false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Gun"))
        {
            enemyHealth -= damage;
            source.Play();
            anim.SetBool("Andando", jump = false);
            anim.SetBool("Idle", idle = false);
            anim.SetBool("Morte", morte = true);
            gameObject.layer = LayerMask.NameToLayer("PréDestruição");
            Destroy(Ari);
            Invoke(nameof(Morri),1.2f);
        }
        else if (collider.gameObject.CompareTag("Zona de Morte"))
        {
            enemyHealth -= damage;
            Destroy(gameObject);
        }
    }
    
    public void Morri()
    {
        Destroy(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

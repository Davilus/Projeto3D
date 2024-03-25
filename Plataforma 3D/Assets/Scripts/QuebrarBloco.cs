using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebrarBloco : MonoBehaviour //, IInterface
{
    private Rigidbody rb;
    
    [SerializeField] private GameObject blocoQuebrado;
    [SerializeField] private float exploxiveForce = 1000f;
    [SerializeField] private float exploxciveRadius = 2f;
    [SerializeField] private float pieceFadeSpeed = 0.25f;
    [SerializeField] private float pieceDestroyDelay = 5f;
    [SerializeField] private float pieceSleepCheckDelay = 0.5f;

    public void Explosion()
    {
        if(TryGetComponent<Collider>(out Collider collider))
        {
            collider.enabled = false;
        }
        if(TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.enabled = false;
        }

        GameObject brokenInstance = Instantiate(blocoQuebrado, transform.position, transform.rotation);

        Rigidbody[] rigidbodies = brokenInstance.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody body in rigidbodies)
        {
            if (rb != null)
            {
                body.velocity = rb.velocity;
            }
            body.AddExplosionForce(exploxiveForce, transform.position, exploxciveRadius);
        }

        StartCoroutine(FadeOutRigidBodies(rigidbodies));
    }
    private IEnumerator FadeOutRigidBodies(Rigidbody[] rigidbodies)
    {
        Destroy(gameObject);
        WaitForSeconds espera = new WaitForSeconds(pieceSleepCheckDelay);
        int ridibodysAtivos = rigidbodies.Length;
       
        while (ridibodysAtivos > 0)
        {
            yield return espera;

            foreach (Rigidbody body in rigidbodies)
            {
                if (body.IsSleeping())
                {
                    ridibodysAtivos--;
                }
            }
        }
        yield return new WaitForSeconds(pieceDestroyDelay);

        float time = 0;
        Renderer[] renderers = Array.ConvertAll(rigidbodies, GetRendererFromRigidboody);

        foreach(Rigidbody body in rigidbodies)
        {
            Destroy(body.GetComponent<Collider>());
            Destroy(body);
        }
        
        while (time < 1)
        {
            float step = Time.deltaTime * pieceFadeSpeed;
            foreach(Renderer renderer in renderers)
            {
                renderer.transform.Translate(Vector3.down * (step/ renderer.bounds.size.y), Space.World);
            }
            time += step;
            yield return null;

        }

        foreach(Renderer renderer in renderers)
            {
                Destroy(renderer.gameObject);
            }

        //Destroy(gameObject);
    }
    private Renderer GetRendererFromRigidboody(Rigidbody rigidbodies)
    {
        return rigidbodies.GetComponent<Renderer>();
    }

    public string InterfacePrompt { get; }
    //public bool Interact(Interactor interactor)
    //{
    //    Explosion();
       
    //    return true;
    //}


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            Explosion();
        }


    }
}

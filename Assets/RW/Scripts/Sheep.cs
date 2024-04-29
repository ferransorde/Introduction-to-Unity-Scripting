using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    public float dropDestroyDelay ; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;


    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);   
    }

    private void HitByHay(){
        
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        sheepSpawner.RemoveSheepFromList(gameObject);
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Hay") && !hitByHay){
            Destroy(other.gameObject);
            HitByHay();
        } else if(other.CompareTag("DropSheep")){
            Drop();
        }
    }

    private void Drop(){
       
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3
        sheepSpawner.RemoveSheepFromList(gameObject);
    }

    public void SetSpawner(SheepSpawner spawner){
        sheepSpawner = spawner;
    }

}

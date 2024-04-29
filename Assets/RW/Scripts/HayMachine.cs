using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{

    public float bounds = 22;
    public float speed;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateMovement(){
        Debug.Log(transform.position.x);
        float input = Input.GetAxisRaw("Horizontal");
        if(input < 0 && transform.position.x > -bounds){
            transform.Translate(transform.right*-speed*Time.deltaTime);
        }
        else if(input > 0 && transform.position.x < bounds){
            transform.Translate(transform.right*speed*Time.deltaTime);
        }

        UpdateShooting();
    }

    private void UpdateShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) {
            shootTimer = shootInterval;
            ShootHay();
        }
    }


    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint .position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        updateMovement();        
        
    }
}

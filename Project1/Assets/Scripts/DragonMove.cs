using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedR;
    [SerializeField] private Windows _windGame;


    private Rigidbody2D _rigDragon;
    private float _rotY;

    void Start()
    {
        _rigDragon = GetComponent<Rigidbody2D>();
        _windGame.StopGame += StopMove;
    }

    void Update()
    {
        CheckArea();
        
         _rotY = Input.GetAxis("Vertical");
        _rigDragon.velocity = transform.right * _speed*Time.deltaTime;
        _rigDragon.transform.Rotate(0, 0, _rotY * _speedR);
    }

    private void CheckArea()
    {
        if (Mathf.Abs(transform.position.x)>9.6)
        {
            transform.position = new Vector2(transform.position.x*0.99f*-1, transform.position.y);
        }
        if(Mathf.Abs(transform.position.y) > 5.5)
        {

            transform.position = new Vector2(transform.position.x, transform.position.y*0.99f*-1);
            
        }
    }

    private void StopMove()
    {
        _rigDragon.constraints = RigidbodyConstraints2D.FreezePosition;

    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 14.0f;
    private Vector3 touchStart;
    private Vector3 touchEnd;

    private PlayerTouchMovement movement;
    public HSpawnManager spawnManager;

    private void Awake()
    {
        movement = GetComponent<PlayerTouchMovement>();
    }
    void Update()
    {
        if(Application.isMobilePlatform)
        {
            OnMobilePlatform();
        }
        else
        {
            OnPCPlatform();
        }
    }

    void OnMobilePlatform()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }

        else if(touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();

        }
    }
    private void OnPCPlatform()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            Debug.Log("touch!!!!");
        }
        else if(Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {

        if(Mathf.Abs(touchEnd.x - touchStart.x )>= dragDistance)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }

        if(touchEnd.y - touchStart.y >= dragDistance)
        {
            movement.MoveToY();
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEnter();
            Debug.Log("스폰합쉬다!!");
        }
    }

}

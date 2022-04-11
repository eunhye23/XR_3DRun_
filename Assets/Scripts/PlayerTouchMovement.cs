using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    private float moveXWidth = 3.1f;
    private float moveTimeX = 0.1f;
    private bool isXMove = false;

    private float originY = 0.55f;
    private float gravity = -7.81f;
    private float moveTimeY = 0.6f;
    private bool isJump = false;

    [SerializeField]
    private float moveSpeed = 20.0f;

    private float rotateSpeed = 300.0f;

    private float limitY = -2.0f;

    private Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        //transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        //³¶¶°·¯Áö·Î ¶³¾îÁ³À» °æ¿ì »ç¸ÁÃ³¸®
        if(transform.position.y <limitY)
        {
            Debug.Log("gameover");
        }
    }
    public void MoveToX(int x)
    {
        if (isXMove == true)
            return;

        if(x >0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }

        else if( x < 0 && transform.position.x > -moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }

    }

    public void MoveToY()
    {
        if (isJump == true)
            return;

        StartCoroutine(OnMoveToY());
    }
    private IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;

        }
        isXMove = false;
    } 
    


    private IEnumerator OnMoveToY()
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity;

        isJump = true;
        rigidbody.useGravity = false;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x,y, transform.position.z);

            yield return null;

        }
        yield return new WaitForSeconds(0.3f);

        isJump = false;
        rigidbody.useGravity = true;
    }
}

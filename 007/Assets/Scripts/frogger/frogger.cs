using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogger : MonoBehaviour

{

    public float speed = 1f;

    public bool isMoving;


    void Update()
    {
        if (isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Move(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Move(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                Move(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                Move(Vector3.right);
            }
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 destination = transform.position + direction * speed;

        Collider[] barrier = Physics.OverlapBox(destination, Vector3.zero, Quaternion.identity, LayerMask.GetMask("Barrier"));
        Collider[] obstacle = Physics.OverlapBox(destination, Vector3.zero, Quaternion.identity, LayerMask.GetMask("Obstacle"));

        if (barrier.Length > 0)
        {
            Debug.LogError("barrier not null");
            return;
        }

        if(obstacle.Length > 0)
        {
            transform.position = destination;
            Death();
        }
        else
        {
            StartCoroutine(Leap(destination));
            isMoving = true;
        }

    }

    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;

        float elapsed = 0f;
        float duration = 0.1f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }

    private void Death()
    {
        transform.rotation = Quaternion.identity;
        enabled = false;
        Debug.LogError("Death");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Death();
        }
    }

}

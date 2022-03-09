using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject VFX;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    bool isJumping;
    bool isGrounded;

    [SerializeField]
    Vector3 RaycastOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = 1;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        VFX.GetComponent<Animator>().SetBool("Idle", (horizontal==0&&vertical == 0) ? true : false);

        RaycastHit hit;

        if(Physics.Raycast(controller.transform.position + RaycastOffset, controller.transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            Debug.DrawRay(controller.transform.position + RaycastOffset, controller.transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.layer == 6)
            {
                VFX.GetComponent<Animator>().SetBool("isJumping", false);
            } else
            {
                VFX.GetComponent<Animator>().SetBool("isJumping", true);
            }
        }
    }
}

using UnityEngine;

public class CameraSwapper : MonoBehaviour
{


    private Animator animator;

    private bool PlayerCamera = true;

    CameraTrigger CT;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SwitchCamera()
    {
        if (!PlayerCamera)
        {
            animator.Play("Player");
        } else if(CT!=null)
        {
            animator.Play(CT.CameraID);
        } else
        {
            return;
        }
        PlayerCamera = !PlayerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            SwitchCamera();
        }
    }

    public void AssignCameraTrigger(CameraTrigger ct = null)
    {
        CT = ct;
        if (!PlayerCamera)
        {
            SwitchCamera();
        }
    }
}

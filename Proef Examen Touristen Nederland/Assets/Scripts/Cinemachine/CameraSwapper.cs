using UnityEngine;

public class CameraSwapper : MonoBehaviour
{


    private Animator animator;

    private bool PlayerCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void SwitchCamera()
    {
        if (PlayerCamera)
        {
            animator.Play("Puzzle");
        } else
        {
            animator.Play("Player");
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
}

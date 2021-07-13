using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(ConfigurableJoint))]
public class PlayerContreoller : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float MouseSensX = 3f;

    [SerializeField]
    private float MouseSensY = 3f;

    [SerializeField]
    private float thrusterForce = 1000f;

    [Header("joint Options")]
    [SerializeField]
    private float jointSpring = 20;
    [SerializeField]
    private float jointaMaxForce = 40;

    private PlayerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();
        SetJointSettings(jointSpring);
    }

    private void Update()
    {
        // calcul speed player
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        // calcul rotation player
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * MouseSensX;

            motor.Rotate(rotation);

        // calcul rotation camera
        float xRot = Input.GetAxisRaw("Mouse Y");

        float  camerarotationX = xRot * MouseSensY;

        motor.RotateCamera(camerarotationX);

        Vector3 thrusterVelocity = Vector3.zero;
        
        // jetpack utlisitation

        if (Input.GetButton("Jump"))
        {
            thrusterVelocity = Vector3.up * thrusterForce;
            SetJointSettings(0f);
        }
        else
        {
            SetJointSettings(jointSpring);
        }

        motor.ApplyThruster(thrusterVelocity);

    }

    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive { positionSpring = _jointSpring, maximumForce = jointaMaxForce };
    }
}

using UnityEngine;

public enum Stance { 
    Stand, 
    Crouch, 
    Prone 
}
/// <summary>
/// The "Puppet" controls for the character.
/// </summary>
public class FPSCharacterController: MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform head;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck gc;
    

    //This might be moved out and to be produced by Input Manager and AI Classes
    private Vector2 moveVector;
    [SerializeField]private Vector2 lookAngle; //Total angle inclusing things like camera kick
    [SerializeField]private Vector2 mouseLookAngle; //records the angle the camera should be exclusively from mouse input

    [SerializeField]private float restoreVelocity;
    [SerializeField]private float restoreSpeed;


    private float baseHeight; 

    
    public Stance currentStance;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5;
    private float speedMultiplier = 1;
    [SerializeField] private float jumpHeight = 3;

    [Header("Camera Control Settings")]
    //Sensitivity might have to be set somewhere else, as senstiivty would be universal to general input, not individual controllable objects.
    [SerializeField] private float sensitivity = 5;
    [SerializeField] private float maxLookAngle = -90;
    [SerializeField] private float minLookAngle = 90;

    //info for current item player is holding
    public UsableItem onHand;
     
    public UsableItem OnHand => onHand;
    public Vector2 MoveVector { set => moveVector = value * Time.deltaTime * (speed); }
    public Vector2 LookVector {
        set {
            Vector2 vector = value * Time.deltaTime * sensitivity;
            mouseLookAngle += vector;
            lookAngle += vector;

            mouseLookAngle.y = Mathf.Clamp(mouseLookAngle.y, minLookAngle, maxLookAngle);
            lookAngle.y = Mathf.Clamp(lookAngle.y, minLookAngle, maxLookAngle);

        }
    }
    public Vector2 LookOffsetVector {
        set {
            lookAngle += value;
        }
    }
    public Stance CurrentStance => currentStance;

    private void Awake()
    {
        baseHeight = head.transform.localPosition.y;
    }
    private void FixedUpdate()
    {
        Move(moveVector);
        Look(lookAngle);

        ResetView(restoreSpeed); //2BMoved to CAM class
    }



    public void Move(Vector2 direction)
    {
        direction *= speedMultiplier;
        transform.Translate(direction.x, 0, direction.y);
    }
    public void Look(Vector2 angle)
    {
        head.transform.localRotation = Quaternion.Euler(-angle.y, 0, 0); //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(0, angle.x, 0);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)
    }
    private void ResetView(float speed) {
        lookAngle.y = Mathf.SmoothDamp(lookAngle.y, mouseLookAngle.y, ref restoreVelocity, speed);
    } //2BMoved to Cam Class
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //for now we will be implementing force, however it's usually unpredictable, so I'd like to have a look into this later
    }
    public void ToStance(Stance stance){
        float heightAndSpeedMultiplier = 1f;
        switch (stance)
        {
            case (Stance.Stand):
                heightAndSpeedMultiplier = 1f;
                break;
            case (Stance.Crouch):
                heightAndSpeedMultiplier = 0.5f;
                break; 
            case (Stance.Prone):
                heightAndSpeedMultiplier = 0.2f;
                break;
        }
        //apply multipliers
        head.transform.localPosition = new Vector3(0, baseHeight * heightAndSpeedMultiplier, 0);

        speedMultiplier = heightAndSpeedMultiplier;
        onHand.Bloom = heightAndSpeedMultiplier;

        currentStance = stance;
    }
}

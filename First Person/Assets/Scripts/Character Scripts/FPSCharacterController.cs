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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck gc;
    [SerializeField] private FPSCamera head;
    

    //This might be moved out and to be produced by Input Manager and AI Classes
    private Vector2 moveVector;

    private float baseHeight; 

    
    public Stance currentStance;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5;
    private float speedMultiplier = 1;
    [SerializeField] private float jumpHeight = 3;


    //info for current item player is holding
    public UsableItem onHand;
     
    public UsableItem OnHand => onHand;
    public Vector2 MoveVector { set => moveVector = value * Time.deltaTime * (speed); }
    public FPSCamera Head => head;

    public Stance CurrentStance => currentStance;

    private void Awake()
    {
        head = GetComponentInChildren<FPSCamera>();
        //head = cam.transform;
        baseHeight = head.transform.localPosition.y;
    }
    private void FixedUpdate()
    {
        Move(moveVector);
    }



    public void Move(Vector2 direction)
    {
        direction *= speedMultiplier;
        transform.Translate(direction.x, 0, direction.y);
    }


    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //for now we will be implementing force, however it's usually unpredictable, so I'd like to have a look into this later
    }
    public void ToStance(Stance stance){
        float heightAndSpeedMultiplier = 1f;
        float bloomMultiplier = 1f;
        switch (stance)
        {
            case (Stance.Stand):
                heightAndSpeedMultiplier = 1f;
                bloomMultiplier = 1f;
                break;
            case (Stance.Crouch):
                heightAndSpeedMultiplier = 0.5f;
                bloomMultiplier = 0.75f;
                break; 
            case (Stance.Prone):
                heightAndSpeedMultiplier = 0.2f;
                bloomMultiplier = 0.5f;
                break;
        }
        //apply multipliers
        head.transform.localPosition = new Vector3(0, baseHeight * heightAndSpeedMultiplier, 0);

        speedMultiplier = heightAndSpeedMultiplier;
        onHand.Bloom = bloomMultiplier;

        currentStance = stance;
    }
}

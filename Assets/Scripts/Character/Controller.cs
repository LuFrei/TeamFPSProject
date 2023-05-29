using UnityEngine;

namespace TWG.Character{
public enum Stance { 
    Stand, 
    Crouch, 
    Prone 
}
/// <summary>
/// The "Puppet" controls for the character.
/// </summary>
public class Controller: MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CameraController head;
    [SerializeField] private EquippedItem hand;

    //This might be moved out and to be produced by Input Manager and AI Classes

    /// Determines the highest point character can stand.
    /// Used to calculate crouch & prone hieghts
    private float baseHeight;
    public Stance currentStance;

    //movement
    private Vector2 moveVector;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5;
    private float speedMultiplier = 1;
    
    //Jump
    [SerializeField] private float jumpHeight = 3;

    //inventory
    private Inventory inv;
    

    
    public EquippedItem Hand => hand;
    public Vector2 MoveVector { set => moveVector = value * Time.deltaTime * (speed); }
    public CameraController Head => head;

    public Stance CurrentStance => currentStance;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
        head = GetComponentInChildren<CameraController>();
        baseHeight = head.transform.localPosition.y;
        EquipItem(0);
    }
    private void FixedUpdate() {
        Move(moveVector);
    }

    // Movement

    public void Move(Vector2 direction) {
        direction *= speedMultiplier;
        transform.Translate(direction.x, 0, direction.y);
    }

    public void Jump() {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        // for now we will be implementing force, however it's usually unpredictable, 
        // so I'd like to have a look into this later
        //->Rigidbody.velocity<-
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
        hand.CurrentRightEquipped.Accuracy.SetBloomModifier(bloomMultiplier);

        currentStance = stance;
    }

    public void EquipItem(int inventoryIndex) {
        hand.ChangeHand(inv.Get(inventoryIndex));
    }
}
}
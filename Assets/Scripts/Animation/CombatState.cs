using UnityEngine;

public class CombatState : State
{
    float gravityValue;
    Vector3 currentVelocity;
    bool grounded;
    bool sheathWeapon;
    float playerSpeed;
    bool attack;
    AudioSource drawWeaponSound;
    AudioSource attackSound;

    Vector3 cVelocity;

    public CombatState(PlayerController _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
        drawWeaponSound = character.GetComponent<AudioSource>();
        attackSound = character.GetComponent<AudioSource>();
    }

    public override void Enter(){
        
        base.Enter();

        sheathWeapon = false;
        input = Vector2.zero;
        velocity = Vector3.zero;
        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;
        attack = false;

        playerSpeed = character.speed;
        grounded = true;
        gravityValue = -9.81f;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (drawWeaponAction.triggered)
        {
            sheathWeapon = true;
        }

        if (attackAction.triggered)
        {
            attack = true;
            attackSound.Play();
        }

        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * character.cameraTransform.right.normalized + velocity.z * character.cameraTransform.forward.normalized;
        velocity.y = 0f;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        character.animator.SetFloat("speed", input.magnitude, character.speedDampTime, Time.deltaTime);

        if (sheathWeapon)
        {
            character.animator.SetTrigger("sheathWeapon");
            stateMachine.ChangeState(character.standing);
        }

        if (attack)
        {
            character.animator.SetTrigger("attack");
            stateMachine.ChangeState(character.attacking);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
 
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = true;
 
        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }
 
        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTime);
        // character.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);
 
        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity), character.rotationDampTime);
        }
    }

    public override void Exit()
    {
        base.Exit();

        gravityVelocity.y = 0f;
        character.playerVelocity = new Vector3(input.x, 0, input.y);
 
        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}

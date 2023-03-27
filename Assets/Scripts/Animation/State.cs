using UnityEngine;
using UnityEngine.InputSystem;
 
public class State
{
    public PlayerController character;
    public StateMachine stateMachine;
 
    protected Vector3 gravityVelocity;
    protected Vector3 velocity;
    protected Vector2 input;
 
    public InputAction moveAction;
    public InputAction crouchAction;
 
    public State(PlayerController _character, StateMachine _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
 
        moveAction = character.playerInput.actions["Move"];
        crouchAction = character.playerInput.actions["Crouch"];
 
    }
 
    public virtual void Enter()
    {
        Debug.Log("enter state: "+this.ToString());
    }
 
    public virtual void HandleInput()
    {
    }
 
    public virtual void LogicUpdate()
    {
    }
 
    public virtual void PhysicsUpdate()
    {
    }
 
    public virtual void Exit()
    {
    }
}
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public abstract class HumanoidState
{
    private CharacterController _controller;

    private StateData _stateData;

    private Humanoid _humanoid;

    public HumanoidState(CharacterController controller, StateData stateData, Humanoid humanoid) {
        _controller = controller;
        _stateData = stateData;
        _humanoid = humanoid;
    }

    public virtual void Move() { }

    public virtual void Run() { }

    public virtual void Jump() { }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidData : ScriptableObject {
    private List<StateData> _stateDatas;
    public List<StateData> StateDatas => _stateDatas;
}

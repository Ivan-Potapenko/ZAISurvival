using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidData : ScriptableObject {
    private List<HumanoidStateData> _stateDatas;
    public List<HumanoidStateData> StateDatas => _stateDatas;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsActivator : MonoBehaviour
{
    [SerializeField]
    private static bool _activateCheat;
    public static bool CheatsIsActive => _activateCheat;

    void Update()
    {
        if(Input.GetKeyDown("`")) {
            _activateCheat = !_activateCheat;
        }
    }
}

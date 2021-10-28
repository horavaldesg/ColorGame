using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputHandler : ScriptableObject
{
    public enum controlSchemes { Gamepad, Keyboard };

    public controlSchemes controlScheme; 

}

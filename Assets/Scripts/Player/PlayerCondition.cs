using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition HP { get { return uiCondition.HP; } }
    Condition stamina { get { return uiCondition.Stamina; } }

    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);
    }
}

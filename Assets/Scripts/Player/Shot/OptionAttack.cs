using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptionAttack : MonoBehaviour
{
    public UnityEvent OpAttack;


    private void OnAttack()
    {
        OpAttack?.Invoke();
    }
}

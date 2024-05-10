using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Leader Info",menuName ="Card Data Leader")]
public class CardDataLeader :Card
{
    private bool isActivateEffects = false;

    public bool IsActivateEffects { get => isActivateEffects; set => isActivateEffects = value; }
}

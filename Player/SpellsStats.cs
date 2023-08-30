using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsStats : MonoBehaviour
{
    public interface ISpell{
    float damage { get; set; }
    float CastCD { get; set; }
    float projectileSpeed { get; set; }
}
}

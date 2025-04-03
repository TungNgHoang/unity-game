using UnityEngine;
using UnityEngine.Events;


public class CharacterEvents
{
    //Character damaged and damage value
    public static UnityAction<GameObject, int> characterDamaged;

    //Character healed and heal value
    public static UnityAction<GameObject, int> characterHealed;
}


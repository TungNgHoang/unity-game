using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;

    Animator animator;
    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    [SerializeField]
    private int _heatlh = 100;
    public int Health
    {
        get
        {
            return _heatlh;
        }
        set
        {
            _heatlh = value;
            if (_heatlh <= 0)
            {
                IsAlive = false;
            }
        }
    }
    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool isInvincible = false;

    private float timeSinceHit = 0;
    public float invicibilityTimer = 0.25f;

    public bool IsAlive {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive: " + value);
        }
    }
    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isInvincible)
        {
            if(timeSinceHit > invicibilityTimer)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            else
            {
                timeSinceHit += Time.deltaTime;
            }
        }
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;

            //Knockback
            LockVelocity = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged?.Invoke(gameObject, damage);

            return true;
        }
        return false;
    }

    public bool Heal(int healthRestored)
    {
        if (IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(0, MaxHealth - Health);
            int actualHeal = Mathf.Min(healthRestored, maxHeal);
            Health += actualHeal;

            return true;
        }
        return false;
    }
}

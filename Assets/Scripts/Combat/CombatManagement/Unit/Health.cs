using System;

public class Health
{
    #region Public Methods

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = this.MaxValue;
    }

    public void GetDamage(int value)
    {
        CurrentValue -= value;

        if (IsDead)
            OnDeath?.Invoke();
    }

    #endregion Public Methods

    #region Public Variables

    public Action OnDeath;
    public int CurrentValue { get; private set; }
    public readonly int MaxValue;

    public bool IsDead => CurrentValue <= 0;

    #endregion Public Variables
}
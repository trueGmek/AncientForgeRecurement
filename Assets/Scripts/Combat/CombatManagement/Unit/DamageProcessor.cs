using UnityEngine;

public class DamageProcessor
{
    public DamageProcessor(Health health, int armourPoints, int damage, string tag)
    {
        _health = health;
        _armourPoints = armourPoints;
        _damage = damage;
        _tag = tag;
    }

    #region Public Methods

    public void ProcessDamage(DamageData damageData)
    {
        int damage = Mathf.Max(1, damageData.damageValue - _armourPoints);

        Debug.Log($"{_tag} Got {damage.ToString()} points of damage");

        _health.GetDamage(damage);
    }

    public DamageData CreateDamageData()
    {
        return new DamageData(_damage);
    }

    #endregion Public Methods

    #region Private Variables

    private readonly Health _health;
    private readonly string _tag;

    private readonly int _armourPoints;

    private readonly int _damage;

    #endregion Private Variables
}
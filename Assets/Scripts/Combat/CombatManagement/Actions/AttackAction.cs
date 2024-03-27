using System.Collections.Generic;
using AFSInterview.Combat;
using UnityEngine;

public class AttackAction : IAction
{
    #region Public Methods

    public AttackAction(Unit unit, Army army, int attackInterval)
    {
        _unit = unit;
        _army = army;
        _attackInterval = attackInterval;
        _cooldownTimer = new CooldownTimer();
    }


    public void Perform()
    {
        _cooldownTimer.Tick();

        if (_cooldownTimer.IsRunning())
        {
            Debug.Log($"{_unit.Name} is on cooldown");
            return;
        }

        Unit target = GetTarget();
        Debug.Log($"{_unit.Name} is attacking {target.Name}");

        DamageData damageData = _unit.DamageProcessor.CreateDamageData(target);
        target.DamageProcessor.ProcessDamage(damageData);
        _cooldownTimer.Start(_attackInterval);

        _unit.FXController.ApplyAttackDamageEffect(damageData, target);
    }

    #endregion Public Methods

    #region Private Methods

    private Unit GetTarget()
    {
        List<Unit> opponents = _army.Opponent.Units;

        return opponents[Random.Range(0, opponents.Count)];
    }

    #endregion Private Methods


    #region Private Variables

    private readonly Army _army;
    private readonly Unit _unit;

    private readonly int _attackInterval;
    private readonly CooldownTimer _cooldownTimer;

    #endregion Private Variables
}
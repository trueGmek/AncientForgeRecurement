using System;
using System.Collections.Generic;

[Serializable]
public class UnitParameters

{
    public int initialHealth;
    public int armour;
    public int damage;
    public int attackInterval;
    public List<UnitAttribute> attributes;
    public List<DamageOverrides> damageOverrides;
}
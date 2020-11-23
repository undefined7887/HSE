using System;
using System.Collections.Generic;
using System.Text;

internal class Soldier
{
    public virtual string Attack()
    {
        return "Shoot from gun";
    }
}

internal class CoolerSoldier : Soldier
{
    public override string Attack()
    {
        return "Shoot from gun and throw a grenade";
    }
}

internal class ManInBlack : Soldier
{
    public virtual string Attack()
    {
        return "Shoot from blaster";
    }
}

internal class ManInBlackBoss : ManInBlack
{
    public override string Attack()
    {
        return "Shoot from blaster and call an army of aliens";
    }
}
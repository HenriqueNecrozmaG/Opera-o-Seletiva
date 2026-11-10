using System;
using UnityEngine;

[Serializable] public class BulletStats : IBulletPrototype<BulletStats>
{
    public string bulletName;
    public Color bulletColor;
    public int materialIndex;

    public BulletStats Clone()
    {
        return (BulletStats)this.MemberwiseClone();
    }
}

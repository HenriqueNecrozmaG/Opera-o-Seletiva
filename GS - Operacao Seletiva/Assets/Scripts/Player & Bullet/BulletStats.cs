using System;
using UnityEngine;

[Serializable] public class BulletStats : IPrototype<BulletStats>
{
    public string bulletName;
    public Color bulletColor;
    public int materialIndex;

    public BulletStats Clone()
    {
        return (BulletStats)this.MemberwiseClone();
    }
}

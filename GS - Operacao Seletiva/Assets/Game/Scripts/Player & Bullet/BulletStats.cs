using System;
using UnityEngine;

[Serializable] public class BulletStats : IBulletPrototype<BulletStats>
{
    public string bulletName;
    public Material bulletMaterial;
    public int materialIndex;

    public BulletStats Clone()
    {
        return (BulletStats)this.MemberwiseClone();
    }
}

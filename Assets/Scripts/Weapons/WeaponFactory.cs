using UnityEngine;
public abstract class WeaponFactory
{

    public enum WeaponType
    {
        Tirapugni,
        Arco,
        Spada
    }
    public static Tirapugni createTirapugni()
    {
        return new Tirapugni();
    }
}
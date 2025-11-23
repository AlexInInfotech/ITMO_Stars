using UnityEngine;

public class Circle : AbstractDamagable
{

    public override float health { get; set; }
    public override void GetDamage(float damage)
    {
        Debug.Log("Circle Damage");
    }
}

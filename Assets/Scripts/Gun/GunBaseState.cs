
using UnityEngine;
public abstract class GunBaseState
{
    public abstract void EnterState(GunStateManager gunState);
    public abstract void UpdateState(GunStateManager gunState);
    public abstract void OnCollisionEnter(GunStateManager gunState);
}

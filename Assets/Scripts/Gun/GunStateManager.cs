using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is context
public class GunStateManager : MonoBehaviour
{

    GunBaseState _gunState;
    GunSingleState _gunSingleState = new GunSingleState();
    GunTrippleState _gunTrippleState = new GunTrippleState();
    GunFanState _gunFanState = new GunFanState();

    void Start()
    {
        //Default gun state
        _gunState = _gunSingleState;

        // This mono behavior script
        _gunState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _gunState.EnterState(this);
    }
    void SwitchGun(GunBaseState state)
    {
        _gunState = state;
        _gunState.EnterState(this);
    }
}

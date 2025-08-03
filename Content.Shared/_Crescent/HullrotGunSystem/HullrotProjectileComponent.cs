﻿using System.Numerics;
using Robust.Shared.Map;


namespace Content.Shared._Crescent.HullrotGunSystem;


/// <summary>
/// This is used for...
/// </summary>
[RegisterComponent]
public sealed partial class HullrotProjectileComponent : Component
{
    // the gun/entity that actually sents out the bullet
    public EntityUid firedFrom;
    // whoever pulled the trigger to cause it to fire.
    public EntityUid shotBy;
    // entities we won't hit
    public HashSet<EntityUid> ignoring;
    // where in the world was this initially aimed at
    // relative-based on grids or the world map so it
    // remains accurate to the true target
    public EntityCoordinates aimedPosition;
    // initial movement
    public Vector2 initialMovement;

}


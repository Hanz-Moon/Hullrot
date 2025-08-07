﻿using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Content.Shared.Weapons.Ranged.Components;
using Robust.Shared.Map;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;


namespace Content.Shared._Crescent.HullrotGunSystem;

[Serializable, NetSerializable]
public class HullrotProjectileFiredEvent : EntityEventArgs
{
    public NetCoordinates shootingPosition;
    public NetCoordinates targetPosition;
    public NetEntity weapon;
    public NetEntity shooter;
    public int projectileKey;
}


/// <summary>
/// This handles...
/// </summary>
public abstract class SharedHullrotProjectileSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _gameTiming = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly SharedHullrotGunSystem _hullGuns = default!;
    //[Dependency] private readonly EntityManager _entityManager = default!;
    public List<Entity<HullrotProjectileComponent>> Projectiles = new List<Entity<HullrotProjectileComponent>>();
    public List<Entity<HullrotProjectileComponent>> FireNextTick =  new List<Entity<HullrotProjectileComponent>>();
    private float tickDelay = 0;

    public override void Initialize()
    {
        base.Initialize();
        tickDelay = 1000.0f/(float)_gameTiming.TickRate;
    }

    public void queueProjectile(Entity<HullrotProjectileComponent> projectile)
    {
        FireNextTick.Add(projectile);
        projectileQueued(projectile);
    }

    public void queueProjectile(EntityUid shooter, Entity<HullrotGunComponent> gun, EntityCoordinates targetPos);
    public abstract void projectileQueued(Entity<HullrotProjectileComponent> projectile);
    public abstract void processProjectiles(float deltaTime);
    public override void Update(float  deltaTime)
    {
        processProjectiles(deltaTime);
        FireNextTick.Clear();
    }
}

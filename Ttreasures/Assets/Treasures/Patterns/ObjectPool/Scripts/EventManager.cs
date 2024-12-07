using UnityEngine;
using UnityEngine.Events;

internal class EventManager 
{
    internal static UnityEvent<Transform> TransferSpawnPositionEvent = new();
    internal static void InvokeSpawnBullet(Transform position) =>
      TransferSpawnPositionEvent.Invoke(position);


    internal static UnityEvent<Bullet> TransferSpentBulletEvent = new ();
    internal static void InvokeRealeseBullet(Bullet bullet) =>
      TransferSpentBulletEvent.Invoke(bullet);
}

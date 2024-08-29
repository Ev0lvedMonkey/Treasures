using UnityEngine;
using UnityEngine.Events;

public class EventManager 
{
    public static UnityEvent<Transform> TransferSpawnPositionEvent = new();
    public static void InvokeSpawnBullet(Transform position) =>
      TransferSpawnPositionEvent.Invoke(position);


    public static UnityEvent<Bullet> TransferSpentBulletEvent = new ();
    public static void InvokeRealeseBullet(Bullet bullet) =>
      TransferSpentBulletEvent.Invoke(bullet);
}

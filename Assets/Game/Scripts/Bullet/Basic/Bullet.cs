namespace SlimeEscape.BulletLogic.Basic
{
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        public BulletEvents Events {get; set;} = new BulletEvents();
        public BulletData Data {get; private set;}
        public void Initialize(BulletData data) {
            Data = data;
            Events.OnBulletInitialized.Invoke();
        }
        public void Spawn(Vector3 position, Vector3 targetGlobalPosition) {
            Events.OnBulletSpawned.Invoke();
        }
    }
}
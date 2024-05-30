namespace SlimeEscape.BulletLogic.Basic
{
    using UnityEngine;

    public class BulletBase : MonoBehaviour
    {
        protected Bullet Bullet { get; private set; }
        protected BulletData Data => Bullet.Data;
        protected BulletEvents Events 
        {
            get => Bullet.Events;
        }

        protected virtual void Awake(){
            Bullet = transform.root.GetComponent<Bullet>();
            if(Bullet == null){
                Debug.LogWarning("Bullet reference is empty at root transform!");
            }
        }
    }
}
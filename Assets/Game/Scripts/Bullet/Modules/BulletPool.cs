namespace SlimeEscape.BulletLogic.Basic
{
    using ScriptableEvents.Base;
    using SlimeEscape.BulletLogic.Additional;
    using UnityEngine;
    using UnityEngine.Pool;

    public class BulletPool : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] SO_BaseEvent<BulletRequest> _OnBulletRequested;
        [Header("Data")]
        [SerializeField] SO_BulletData _data;
        [SerializeField] Bullet _prefab;
        [Header("Settings")]
        [SerializeField] int _initialAmountToPool;
        [SerializeField] int _maxPoolAmount;

        private ObjectPool<Bullet> _pool;
        private void Start() {
            _pool = new ObjectPool<Bullet>(
                () => {
                    Bullet poolObject = Instantiate(_prefab);
                    poolObject.Initialize(_data, DisablePoolObject);
                    poolObject.transform.SetParent(transform, false);
                    return poolObject;
                }, bullet => {
                    bullet.gameObject.SetActive(true);
                }, bullet => {
                    bullet.gameObject.SetActive(false);
                }, bullet => {
                    Destroy(bullet.gameObject);
                }, false, _initialAmountToPool, _maxPoolAmount
            );
        }

        private void OnObjectInstantiateRequest(BulletRequest request){
            _pool.Get().Spawn(request);
            
        } 
        private void DisablePoolObject(Bullet poolObject) => _pool.Release(poolObject);

        private void OnEnable() {
            _OnBulletRequested += OnObjectInstantiateRequest;    
        }
        private void OnDisable() {
            _OnBulletRequested -= OnObjectInstantiateRequest;    
        }
    }
}
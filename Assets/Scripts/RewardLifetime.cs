using UnityEngine;

public class RewardLifetime : MonoBehaviour
{
    public float lifetime = 10.0f; // 보상 객체의 생명 시간
    public float spawnTime; // 보상 객체의 생성 시각

    public delegate void RewardDestroyed(string deleteType);
    public event RewardDestroyed OnDestroyEvent;

    private bool isDestroyed = false; // 보상 객체가 이미 삭제되었는지 여부를 추적

    void Start()
    {
        Invoke("AutoDestroy", lifetime);
    }

    void AutoDestroy()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            OnDestroyEvent?.Invoke("자동 삭제");
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            OnDestroyEvent?.Invoke("플레이어 삭제");
        }
    }
}

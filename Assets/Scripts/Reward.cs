using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private int rewardScore;  // 리워드의 점수

    public int RewardScore
    {
        get { return rewardScore; }
        private set { rewardScore = value; }
    }
}

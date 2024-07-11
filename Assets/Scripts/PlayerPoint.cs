using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    private int playerPoints = 0;  // 플레이어의 포인트

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌 감지");
        Debug.Log(other.gameObject.name);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Reward"))
        {
            Debug.Log("Reward와 충돌");
            Reward reward = other.gameObject.GetComponent<Reward>();  
            if (reward != null)
            {
                AddPoints(reward.rewardScore);
                Debug.Log("Reward 객체 삭제");
                Destroy(other.gameObject);
            }
        }
    }


    public void AddPoints(int pointsToAdd)
    {
        playerPoints += pointsToAdd;  // 포인트를 추가합니다.
        Debug.Log("포인트 추가: " + pointsToAdd + ", 현재 포인트: " + playerPoints);
    }

    public int getPoint()
    {
        return playerPoints;
    }
}

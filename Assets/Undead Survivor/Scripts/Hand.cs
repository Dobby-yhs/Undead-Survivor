using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool bIsLeft;
    public SpriteRenderer spriter;

    SpriteRenderer player;
    Scanner scanner;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
        scanner = GetComponentInParent<Scanner>();
    }

    void LateUpdate()
    {
        bool bIsReverse = player.flipX;

        if (bIsLeft)  // 근접 무기
        {
            transform.localRotation = bIsReverse ? leftRotReverse : leftRot;
            spriter.flipY = bIsReverse;
            spriter.sortingOrder = bIsReverse ? 4 : 6;
        }
        else if (scanner.nearestTarget)
        {
            Vector3 targetPos = scanner.nearestTarget.position;
            Vector3 dir = targetPos - transform.position;
            transform.localRotation = Quaternion.FromToRotation(Vector3.right, dir);

            bool bIsRotA = transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270;
            bool bIsRotB = transform.localRotation.eulerAngles.z < -90 && transform.localRotation.eulerAngles.z > -270;
            spriter.flipY = bIsRotA || bIsRotB;
            spriter.sortingOrder = 6;
        }
        else  // 원거리 무기
        {
            transform.localPosition = bIsReverse ? rightPosReverse : rightPos;
            spriter.flipX = bIsReverse;
            spriter.sortingOrder = bIsReverse ? 6 : 4;
        }
    }
}

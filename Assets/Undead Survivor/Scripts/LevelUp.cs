using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    List<int> itemList = new List<int>();

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    void Start()
    {
        for (int index = 0; index < items.Length; index++)
        {
            itemList.Add(index);
        }
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);
        AudioManager.instance.EffectBgm(true);
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(false);
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void SuffleList(List<int> list)
    {
        for (int index = 0; index < list.Count; index++)
        {
            int randIndex = Random.Range(index, list.Count);
            int temp = list[index];
            list[index] = list[randIndex];
            list[randIndex] = temp;
        }
    }

    void Next()
    {
        // 모든 아이템 비활성화
        foreach (Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        List<int> availableList = new List<int>();

        // 0 ~ 3번 아이템 중 레벨업 가능한 것만 리스트에 추가가
        for (int index = 0; index < 5; index++)
        {
            if (items[index].level < items[index].data.damages.Length)
            {
                availableList.Add(index);
            }
        }

        // 리스트 셔플
        SuffleList(availableList);

        List<int> result = new List<int>();

        if (availableList.Count >= 3)
        {
            result.AddRange(availableList.GetRange(0, 3));
            while (result.Count < 3)
            {
                int rand = availableList[Random.Range(0, availableList.Count)];

                if (!result.Contains(rand))
                {
                    result.Add(rand);
                }
            }
        }
        else if (availableList.Count > 0)
        {
            result.AddRange(availableList);
            if (!result.Contains(4))
            {
                result.Add(4);
            }
        }
        else
        {
            result.Add(4);
        }

        // 결과 아이템 활성화
        foreach (int index in result)
        {
            items[index].gameObject.SetActive(true);
        }
        // }

        // // 그 중에서 랜덤 3개 아이템만 활성화
        //     int[] random = new int[3];
        // while (true)
        // {
        //     random[0] = itemList[Random.Range(0, itemList.Count)];
        //     if (items[random[0]].level == items[random[0]].data.damages.Length)
        //     {
        //         itemList.Remove(random[0]);
        //     }
        //     random[1] = itemList[Random.Range(0, itemList.Count)];
        //     if (items[random[1]].level == items[random[1]].data.damages.Length)
        //     {
        //         itemList.Remove(random[1]);
        //     }
        //     random[2] = itemList[Random.Range(0, itemList.Count)];
        //     if (items[random[2]].level == items[random[2]].data.damages.Length)
        //     {
        //         itemList.Remove(random[2]);
        //     }
        //     Debug.Log($"3개만 활성화, {random[0]}, {random[1]}, {random[2]}");

        //     if (random[0] != random[1] && random[1] != random[2] && random[0] != random[2])
        //     {
        //         Debug.Log("while 문 탈출");
        //         break;
        //     }
        // }

        // for (int index = 0; index < random.Length; index++)
        // {
        //     Item randItem = items[random[index]];

        //     // 만렙 아이템의 경우는 소비아이템으로 대체
        //     if (randItem.level == randItem.data.damages.Length)
        //     {
        //         items[4].gameObject.SetActive(true);
        //     }
        //     else
        //     {
        //         randItem.gameObject.SetActive(true);
        //     }
        // }
        // Debug.Log("===================Next 끝=================");
    }
}

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
    }
}

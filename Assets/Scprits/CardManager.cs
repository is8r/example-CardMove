using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    //山札のリスト
    public List<GameObject> cards;

    //手札のリスト
    public List<GameObject> playerCards = new List<GameObject>();

    public void OnAction()
    {
        //リセット
        Reset(playerCards);

        //カードを抜き出す
        playerCards.Add(GetCard());
        playerCards.Add(GetCard());
        playerCards.Add(GetCard());

        //カードの移動
        Move(playerCards, 100);
    }

    //リセット
    public void Reset(List<GameObject> _cards)
    {
        //元の位置に戻す
        Move(playerCards, -100);

        //手札から山札に戻す
        for (int i = 0; i < _cards.Count; i++)
        {
            cards.Add(_cards[i]);
        }
        _cards.Clear();
    }

    //カードを1つ抜き出す
    public GameObject GetCard()
    {
        //山札からランダムにカードを取得する
        int num = Random.Range(0, cards.Count);
        GameObject re = cards[num];
        cards.RemoveAt(num);
        return re;
    }

    //カードの移動
    public void Move(List<GameObject> _cards, float posY)
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            //移動
            RectTransform rectTransform = _cards[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, posY);
        }
    }

}

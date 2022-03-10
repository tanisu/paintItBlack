using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<GameObject> chips = new List<GameObject>();
    Vector3 targetPos;
    int moveDistance = 1;
    public bool isMoving;
    public bool isTargetting;


    private void Update()
    {
        if (GameManager.I.gameMode == GameManager.GAMEMODE.GAMEOVER)
        {
            gameObject.SetActive(false);
        }
    }
    public void Move(Vector3 endpos)
    {
        if(GameManager.I.gameMode == GameManager.GAMEMODE.GAMEOVER)
        {
            //gameObject.SetActive(false);
            return;
        }
        targetPos = endpos;
        StartCoroutine(_move());
    }

    public void TurnColor()
    {
        foreach(GameObject chip in chips)
        {
            chip.GetComponent<SpriteRenderer>().color = Color.black;
            chip.tag = "BlackChip";
            GameManager.I.turnCount++;
        }
        chips.Clear();
        moveDistance = Random.Range(1,8);
    }

    IEnumerator _move()
    {
        isMoving = true;
        while ((transform.position - targetPos).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveDistance * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WhiteChip"))
        {
            chips.Add(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            isTargetting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WhiteChip"))
        {
            chips.Remove(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            isTargetting = false;
        }

    }

}

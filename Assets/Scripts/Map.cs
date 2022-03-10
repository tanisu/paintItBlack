using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject whiteChip, blackChip,enemyPrefab;
    Enemy enemy;
    [SerializeField] int w,h;
    [SerializeField] TargetController target;
    int chipSize = 8;
    int idx;
    List<GameObject> tmps;
    
    public float hiritu;

    void Start()
    {
        tmps = new List<GameObject>();
        
        for(int x = 0;x < w / chipSize; x++)
        {
            for(int y = 0;y < h / chipSize; y++)
            {
                Vector2 pos = new Vector2((float) x * chipSize / 100 - ((float)(w - chipSize) / 100 /2) ,(float)y * chipSize / 100 - ((float)(h - chipSize) / 100 / 2));
                GameObject tmp = Instantiate(whiteChip,pos,Quaternion.identity,transform);
                tmps.Add(tmp);
                
            }
        }

        GameManager.I.chipsCount = tmps.Count;
        enemy = Instantiate(enemyPrefab, tmps[(tmps.Count / 2) + (h / chipSize / 2)].transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
        idx = Random.Range(0, tmps.Count);
        enemy.Move(tmps[idx].transform.position);
        target.xLimit = tmps[tmps.Count - 1].transform.position.x;  
        target.yLimit = tmps[tmps.Count - 1].transform.position.y;
    }


    private void Update()
    {
        if(GameManager.I.gameMode == GameManager.GAMEMODE.GAMEOVER)
        {
            return;
        }
        if (!enemy.isMoving)
        {
            idx = Random.Range(0,tmps.Count);
            enemy.Move(tmps[idx].transform.position);
        }

        if (enemy.isTargetting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.I.PlaySE(SESoundData.SE.MISS);
                StartCoroutine(_flashBakcGround());
                enemy.TurnColor();
                GameManager.I.UpdateHiritu();
            }
        }
    }

    IEnumerator _flashBakcGround()
    {
        for(int i = 0;i < 10; i++)
        {
            Camera.main.backgroundColor = Color.white;
            yield return new WaitForSeconds(0.023f);
            Camera.main.backgroundColor = Color.black;
            yield return new WaitForSeconds(0.027f);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    private IEnumerator coroutine;
    int x, y;
    string shot = "";
    TurnManager tm;
    List<string> TilesShot = new List<string>();
    static int totalShots = 0;

   public Cannon[] cannons;
    void Start()
    {
        tm = Camera.main.GetComponent<TurnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator Shoot()
    {
        int i = 0;

        while (true) 
        {
            if (++totalShots > 62)
                break;

            x = Random.Range(0, 8);
            y = Random.Range(0, 8);
            shot = x + "," + y;
            if (TilesShot.Contains(shot) == false)
            {
                string find = "/PlayerFleet/BRow" + y + "/Tile" + x;
                GameObject tile = GameObject.Find(find);

                Tile victim = tile.GetComponent<Tile>();
                Tile.targeted = victim;
                cannons[i].Fire(tile.transform.position);

                TilesShot.Add(x + "," + y);
                //print(shot);
                i++;
                yield return new WaitForSeconds(2);
            }
            if (i > 3)
                break;   // fired all four shots
        }
        i = 0;
        tm.turnTxt.text = "Player Turn";
        tm.turnTxt.color = Color.blue;
        tm.turn = "player";
    }


}

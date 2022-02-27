using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour
{
    public GameObject model1, model2, model3, model4;
    public string rowName;
   
    void Start()
    {
        StartCoroutine(SailAway());
    }

    IEnumerator SailAway() 
    {
        GetRndPos(model4);
        yield return new WaitForSeconds(0.2f);   
        GetRndPos(model3);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model3);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model2);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model2);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model2);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model1);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model1);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model1);
        yield return new WaitForSeconds(0.2f);
        GetRndPos(model1);

    }

    void GetRndPos(GameObject ship)
     {
        int rowNum=0;
        int colNum=0;
        Battleship bs = ship.GetComponent<Battleship>();


        for (int i = 0; i < 16; i++)
        {
            rowNum = Random.Range(0, 8);
            colNum = Random.Range(0, 8-bs.size);
            string randomRow = rowName + rowNum;
            GameObject row = GameObject.Find(randomRow);

            Tile[] tiles = row.GetComponentsInChildren<Tile>();
            Tile anchor = tiles[colNum];

            if (anchor.status.ToLower().Equals("open") && CanFit(tiles,colNum,bs.size))
            {
                float xPos = anchor.transform.position.x;
                if (bs.size == 2)
                    xPos = xPos + 0.5f;
                if(bs.size == 3)
                    xPos = xPos + 1f;
                if (bs.size == 4)
                    xPos = xPos + 1.5f;

                for (int occ = colNum; occ < colNum + bs.size; occ++)
                {
                    tiles[occ].status = "occupied";
                }
                GameObject boat = Instantiate(ship, new Vector3(xPos, anchor.transform.position.y, 0f), Quaternion.identity);
                // we're creating subs (AI fleet), so make them invisible
                if (rowName != "BRow")
                    boat.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

                //print("ship " + boat.name + " placed at " + Time.time + " anchored at row " + rowNum + "," + anchor);
                return;
            }
        }

        print("could not find available space for ship of size " + bs.size);
    }

    // anchor tile is an available spot, see if there're free spots to the right
    bool CanFit(Tile [] row, int anchorTile, int shipSize)
    {
        int gap = 0;
        // go up to the end of row
        for(int i=anchorTile;i<8;i++) {

            if (row[i].status.ToLower().Equals("open"))
                gap++;
            else
                break;
        }
        if (gap > shipSize)
            return true;
  
        return false;
        /*
        gap = 0;
        for (int i = anchorTile; i >0; i--) // go to start of row
        {
            if (row[i].status.ToLower().Equals("open"))
                gap++;
            else
                break;
        }
        if (gap > shipSize)
            return true;
        return false;
        */
    }
}

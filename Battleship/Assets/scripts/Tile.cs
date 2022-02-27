using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Tile targeted;

    bool gamestart = false;
    public string status = "open";
    public GameObject hit;
    public GameObject miss;
    Battleship contained;
    TurnManager tm;
    AIShoot ais;

    GameObject battery;
    Cannon[] cannons;


    private void Start()
    {
        Invoke("StartGame", 3);
        tm = Camera.main.GetComponent<TurnManager>();
        ais = Camera.main.GetComponent<AIShoot>();
        battery = GameObject.Find("Battery");
        cannons = battery.GetComponentsInChildren<Cannon>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(name + " collided with " + collision.tag);
        if(collision.tag.Equals("Cannonball") && targeted == this)
        {
            TileHit();
            Destroy(collision.gameObject);
            targeted = null;
        }

        // when ship is placed on the map:
        if(collision.tag.Equals("Ship")|| collision.tag.Equals("Sub"))
        {
            // if a ship is on this tile, the status will be set to "occupied" by Factory
            if (status.ToLower().Equals("open"))
                status = "buffer";
            contained = collision.gameObject.GetComponent<Battleship>();
        }
    }

    // ball arrived at the targeted tile
    private void TileHit()
    {
         if (status == "occupied")
          {
             Instantiate(hit, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
             contained.hits = contained.hits + 1;
         }
          else
             Instantiate(miss, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
    }
    
    void OnMouseDown()
    {
        if (gamestart)
        {
            targeted = this;
            // print("targeted tile: " + this.gameObject.name);
            
            if (tm.turn == "player")
            {
                TurnManager.turncount++;
                cannons[TurnManager.turncount-1].Fire(transform.position);
                
            }
            if (tm.playerTurns <= TurnManager.turncount)
            {
                TurnManager.turncount = 0;
                tm.turn = "AI";

                tm.turnTxt.color = Color.red;
                Invoke("AITurn", 2f);
            }
            tm.turnTxt.text = "Turn: " + tm.turn;
        }
    }

    void AITurn()
    {
        StartCoroutine(ais.Shoot());
    }

    void StartGame()
    {
        gamestart = true;
    }




}

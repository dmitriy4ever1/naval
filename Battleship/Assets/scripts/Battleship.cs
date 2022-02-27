using UnityEngine.UI;
using UnityEngine;

public class Battleship : MonoBehaviour
{
    TurnManager tm;
    public int size;
    public int hits=0;

    static int four = 1;
    static int three = 2;
    static int two = 3;
    static int one = 4;


    private void Start()
    {
        tm = Camera.main.GetComponent<TurnManager>();
    }
    private void Update()
    {
        if (hits == size)
        {
            if (gameObject.tag == "Sub")
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                if (size == 4)
                    four--;
                if (size == 3)
                    three--;
                if (size == 2)
                    two--;
                if (size == 1)
                    one--;
                hits++;
            }
            if (gameObject.tag == "Ship")
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
                hits++;
            }
            tm.statTxt.text = "4:" + four + "   3:" + three + "   2:" + two + "   1:" + one;

        }
    }
}

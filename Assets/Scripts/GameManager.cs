using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card_data> deck = new List<Card_data>();
    public List<Card_data> player_deck = new List<Card_data>();
    public List<Card_data> ai_deck = new List<Card_data>();
    public List<Card_data> player_hand = new List<Card_data>();
    public List<Card> ai_hand = new List<Card>();
    public List<GameObject> ai_hand_objs = new List<GameObject>();
    public List<Card_data> discard_pile = new List<Card_data>();

    public Vector3 player_hand_spawnpoint;
    public Vector3 ai_hand_spawnpoint;
    public Vector3 offset;
    public Canvas canvas;
    public Card blank;
    public Card ai_card;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.Environment.TickCount);
        canvas = FindAnyObjectByType<Canvas>();
        Deal();
        Player_Turn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        Shuffle(player_deck);
        Shuffle(ai_deck);
        for (int i = 0; i < 2; i++)
        {
            //create new blank card
            Card current_card = Instantiate(blank, player_hand_spawnpoint + offset, Quaternion.identity, canvas.transform); 

            //move the offest over for the next card
            offset.x += 200;

            //fill the data for the blank card
            current_card.data = player_deck[i];

            //remove the card from the deck
            player_deck.Remove(current_card.data);

            //add the card to the hand
            player_hand.Add(current_card.data);

            //child the card to the canvas to get it to show on the screen
            //current_card.transform.SetParent(canvas.transform);  (<-was evil code/was diff than wanted)
        }
        
        for (int i = 0; i < 2; i++)
        {
            //create new blank card
            Card current_ai_card = Instantiate(ai_card, ai_hand_spawnpoint + offset, Quaternion.identity, canvas.transform); 

            //move the offest over for the next card
            offset.x += 200;

            //fill the data for the blank card
            current_ai_card.data = ai_deck[i];

            //remove the card from the deck
            ai_deck.Remove(current_ai_card.data);

            //add the card to the hand
            ai_hand.Add(current_ai_card);
            
            ai_hand_objs.Add(current_ai_card.gameObject);

            //hope ts works the copy strat has failed yet
        } 
         
    }

    void Shuffle(List<Card_data> _deck)
    {
        System.Random rng = new System.Random();
        for (int i = 0; i < _deck.Count; i++)
        {
            int j = rng.Next(_deck.Count);
            Card_data temp = _deck[i];
            _deck[i] = _deck[j];
            _deck[j] = temp;
        }
    }

    void AI_Turn()
    {
        //choose a card by picking a random number between 0 and AI_hand size
        
        ai_hand_objs[ Random.Range(0, ai_hand_objs.Count)].transform.GetChild(7).gameObject.SetActive(false);
        //reveal the card that was chosen


        //Player_Turn();

        /*
        {//pick a random card from ai_hand
        player-= ai_hand[rand].card_data.damage
        //add ai_hand[rand} to discard pile}
        */
    }

    /*void end turn()
        {
        //move all cards from table to discard pile
        ai_turn()
        }
        */
    void Player_Turn()
    {
        AI_Turn();
    }
    
}

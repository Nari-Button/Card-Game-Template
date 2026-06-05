using UnityEngine;

public class Table : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.GetComponent<Card>().data.card_name);
    }
}
/*  after decting then stop movement on all cards to signify the end of player turn
        on drag = true currently so make it false if card collison

    switch ai turn 
        already done in player turn i believe?

    have choose one of the 2 cards and then place on table
        which ever is already uncovered bc it's already random anyways for that

    figure out how much damage taken to both losing side 
        add health player wise and cancel what can on the cards then add the extra damge from whoever wins to the loser
    
    then apply it 
        if card health = # and other does this damage count how many time it takes to kill then do the same with the other and less times attack = damage loser main health
    
    then move onto new round
        i think this will just automatically happen
   
    continue till 0 health on one reached
        figure out health of players and ai maybe 25 so it doesn't take too long or maybe 30
*/

// everytime i cry it's about you and everytime i laugh it's for you too 
// so do your little dance around my room i know im gonna join you soon
// 1-800 he's so handsome he's my hero 1-800 let me 1800 blow your mind
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Tyler McPhee
 * 0670448
 * 
 * Matching Game
 * COMP-4478-WA
 * 03-07-2020
 */

public class Game : MonoBehaviour{

    public GameObject GameOver;
    public GameObject PlayAgain;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;

    public GameObject card1_mask;
    public GameObject card2_mask;
    public GameObject card3_mask;
    public GameObject card4_mask;
    public GameObject card5_mask;
    public GameObject card6_mask;
    public GameObject card7_mask;
    public GameObject card8_mask;

    int selected = 0;
    int pairs = 0;
    int maxPairs = 4;
    public GameObject Pick1;
    public GameObject Pick2;
    public GameObject Pick1_mask;
    public GameObject Pick2_mask;

    int timer = 0;
    int wait = 0;

    bool isgameover = false;

    void shuffle(int[] texts){
        // Knuth shuffle algorithm
        for (int t = 0; t < texts.Length; t++){
            int tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

    Sprite getsprite(int val){
        switch (val){
            case 1:
                return Resources.Load<Sprite>("cards/card1");
            case 2:
                return Resources.Load<Sprite>("cards/card2");
            case 3:
                return Resources.Load<Sprite>("cards/card3");
            case 4:
                return Resources.Load<Sprite>("cards/card4");
        }

        return Resources.Load<Sprite>("cards/cardcover");
    }

    void setupcards(){
        /*RANDOM PLACEMENT OF CARDS*/
        int[] stack = { 1, 1, 2, 2, 3, 3, 4, 4 };
        shuffle(stack);

        for (int i = 0; i < 8; i++){
            if (i == 0){
                card1.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 1){
                card2.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 2){
                card3.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 3){
                card4.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 4){
                card5.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 5){
                card6.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 6){
                card7.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
            else if (i == 7){
                card8.GetComponent<SpriteRenderer>().sprite = getsprite(stack[i]);
            }
        }
    }

    // Start is called before the first frame update
    void Start(){
        setupcards();
    }

    // Update is called once per frame
    void Update(){
        if (wait == 0){
            if (Input.GetMouseButtonDown(0)){
                Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (card1.GetComponent<SpriteRenderer>().bounds.Contains(position)){
                    if (selected == 0){
                        Pick1 = card1;
                        Pick1_mask = card1_mask;
                    }
                    else{
                        Pick2 = card1;
                        Pick2_mask = card1_mask;
                    }
                    card1_mask.SetActive(false);
                    selected++;
                }
                else if (card2.GetComponent<SpriteRenderer>().bounds.Contains(position)){
                    if (selected == 0){
                        Pick1 = card2;
                        Pick1_mask = card2_mask;
                    }
                    else{
                        Pick2 = card2;
                        Pick2_mask = card2_mask;
                    }
                    card2_mask.SetActive(false);
                    selected++;
                }
                else if (card3.GetComponent<SpriteRenderer>().bounds.Contains(position))
                {
                    if (selected == 0)
                    {
                        Pick1 = card3;
                        Pick1_mask = card3_mask;
                    }
                    else
                    {
                        Pick2 = card3;
                        Pick2_mask = card3_mask;
                    }
                    card3_mask.SetActive(false);
                    selected++;
                }
                else if (card4.GetComponent<SpriteRenderer>().bounds.Contains(position))
                {
                    if (selected == 0)
                    {
                        Pick1 = card4;
                        Pick1_mask = card4_mask;
                    }
                    else
                    {
                        Pick2 = card4;
                        Pick2_mask = card4_mask;
                    }
                    card4_mask.SetActive(false);
                    selected++;
                }
                else if (card5.GetComponent<SpriteRenderer>().bounds.Contains(position))
                {
                    if (selected == 0)
                    {
                        Pick1 = card5;
                        Pick1_mask = card5_mask;
                    }
                    else
                    {
                        Pick2 = card5;
                        Pick2_mask = card5_mask;
                    }
                    card5_mask.SetActive(false);
                    selected++;
                }
                else if (card6.GetComponent<SpriteRenderer>().bounds.Contains(position))
                {
                    if (selected == 0)
                    {
                        Pick1 = card6;
                        Pick1_mask = card6_mask;
                    }
                    else
                    {
                        Pick2 = card6;
                        Pick2_mask = card6_mask;
                    }
                    card6_mask.SetActive(false);
                    selected++;
                }
                else if (card7.GetComponent<SpriteRenderer>().bounds.Contains(position))
                {
                    if (selected == 0)
                    {
                        Pick1 = card7;
                        Pick1_mask = card7_mask;
                    }
                    else
                    {
                        Pick2 = card7;
                        Pick2_mask = card7_mask;
                    }
                    card7_mask.SetActive(false);
                    selected++;
                }
                else if (card8.GetComponent<SpriteRenderer>().bounds.Contains(position)){
                    if (selected == 0)
                    {
                        Pick1 = card8;
                        Pick1_mask = card8_mask;
                    }
                    else
                    {
                        Pick2 = card8;
                        Pick2_mask = card8_mask;
                    }
                    card8_mask.SetActive(false);
                    selected++;
                }
                else if (PlayAgain.GetComponent<SpriteRenderer>().bounds.Contains(position)){
                    if (isgameover){
                        setupcards();
                        card1_mask.SetActive(true);
                        card2_mask.SetActive(true);
                        card3_mask.SetActive(true);
                        card4_mask.SetActive(true);
                        card5_mask.SetActive(true);
                        card6_mask.SetActive(true);
                        card7_mask.SetActive(true);
                        card8_mask.SetActive(true);

                        selected = 0;
                        pairs = 0;

                        GameOver.SetActive(false);
                        PlayAgain.SetActive(false);
                        isgameover = false;
                    }
                }
            }



            if (selected == 2){
                if (Pick1.GetComponent<SpriteRenderer>().sprite.name == Pick2.GetComponent<SpriteRenderer>().sprite.name)
                {
                    pairs++;
                    selected = 0;
                }
                else
                {
                    wait = 1;
                }
            }

            if(pairs == maxPairs){
                GameOver.SetActive(true);
                PlayAgain.SetActive(true);
                isgameover = true;
            }

        }
        else{
            timer++;
            if(timer == 30){
                wait = 0;
                timer = 0;

                Pick1_mask.SetActive(true);
                Pick2_mask.SetActive(true);
                selected = 0;
            }

        }
    }
}

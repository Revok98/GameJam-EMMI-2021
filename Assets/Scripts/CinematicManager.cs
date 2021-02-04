using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{

    public GameObject character;
    public List<GameObject> charaPoints = new List<GameObject>();
    public GameObject monster;
    public List<GameObject> monsterPoints = new List<GameObject>();
    public Image image;
    public bool isDialogDone;
    public bool isDialog2Done;
    private bool isTransitionDone;
    private bool isTransitionOpenDone;
    private CharacterAnimation charaAnimation;
    public MonsterAnimated monsterAnimation;
    public GameObject plush;
    private enum characterPosStates { START, POS1, POS2, BED };
    private enum monsterPosStates { START, POS1, POS2, POS3};
    private characterPosStates characterPosState;
    private monsterPosStates monsterPosState;
    private float minPointDistance = 0.1f;

    public List<DialogPage> m_dialogPlayer;
    public List<DialogPage> m_dialogMonster;
    public DialogManager m_dialogDisplayer;
    private bool go_monster = false;
    private bool first_dial = false;
    private bool second_dial = false;
    private bool end = false;

    private void Start()
    {
        charaAnimation = character.GetComponent<CharacterAnimation>();
        charaAnimation.state = CharacterAnimation.states.WALKING;
        characterPosState = characterPosStates.START;
        monsterPosState = monsterPosStates.START;
        monster.SetActive(false);
        isDialogDone = false;
        isDialog2Done = false;
        image.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.GetComponent<OpeningDialog>().alreadyTalk || m_dialogDisplayer.isActiveAndEnabled) {
            return; 
        }

        switch (characterPosState)
        {
            case (characterPosStates.START):
                character.transform.position = 
                    Vector3.MoveTowards(character.transform.position, charaPoints[0].transform.position, 0.1f);
                character.transform.LookAt(charaPoints[0].transform.position);
                if (Vector3.Distance(character.transform.position, charaPoints[0].transform.position) <= minPointDistance)
                    characterPosState = characterPosStates.POS1;
                break;
            case (characterPosStates.POS1):
                character.transform.position =
                    Vector3.MoveTowards(character.transform.position, charaPoints[1].transform.position, 0.1f);
                character.transform.LookAt(charaPoints[1].transform.position);
                if (Vector3.Distance(character.transform.position, charaPoints[1].transform.position) <= minPointDistance)
                    characterPosState = characterPosStates.POS2;
                break;
            case (characterPosStates.POS2):
                StartCoroutine(FadeImage(false, true,true));
                charaAnimation.state = CharacterAnimation.states.IDLE;
                character.transform.LookAt(new Vector3(charaPoints[2].transform.position.x,1, charaPoints[2].transform.position.z));
                //playCharaDialog();
                break;
            case (characterPosStates.BED):
                if (!go_monster)
                {
                    StartCoroutine(FadeImage(true, false, false));
                    Destroy(plush);
                    charaAnimation.state = CharacterAnimation.states.HIDING;
                    character.transform.position = charaPoints[2].transform.position;
                    character.transform.LookAt(charaPoints[3].transform.position);
                }
                break;
            default:
                break;

        }

        if (characterPosState == characterPosStates.BED && go_monster)
        {
            monster.SetActive(true);
            switch (monsterPosState)
            {
                case (monsterPosStates.START):
                    //StopAllCoroutines();
                    monster.transform.position =
                        Vector3.MoveTowards(monster.transform.position, monsterPoints[0].transform.position, 0.1f);
                    monster.transform.LookAt(monsterPoints[0].transform.position);
                    if (Vector3.Distance(monster.transform.position, monsterPoints[0].transform.position) <= minPointDistance)
                        monsterPosState = monsterPosStates.POS1;
                    break;
                case (monsterPosStates.POS1):
                    monster.transform.position =
                        Vector3.MoveTowards(monster.transform.position, monsterPoints[1].transform.position, 0.1f);
                    monster.transform.LookAt(monsterPoints[1].transform.position);
                    if (Vector3.Distance(monster.transform.position, monsterPoints[1].transform.position) <= minPointDistance)
                        monsterPosState = monsterPosStates.POS2;
                    break;
                case (monsterPosStates.POS2):
                    monster.transform.position =
                        Vector3.MoveTowards(monster.transform.position, monsterPoints[2].transform.position, 0.1f);
                    monster.transform.LookAt(monsterPoints[2].transform.position);
                    if (Vector3.Distance(monster.transform.position, monsterPoints[2].transform.position) <= minPointDistance)
                        monsterPosState = monsterPosStates.POS3;
                    break;
                case (monsterPosStates.POS3):
                    monsterAnimation.state = MonsterAnimated.states.STOP;
                    monster.transform.LookAt(new Vector3(monsterPoints[3].transform.position.x, 1, monsterPoints[3].transform.position.z));
                    StartCoroutine(FadeImage(false, false,true));
                    break;
                default:
                    break;
            }
        }
        if (end) {
            goToScene nextScene = new goToScene();
            nextScene.SceneName = "Menu";
            nextScene.goToMyScene();
        }

    }

    private void playCharaDialog() 
    {
        characterPosState = characterPosStates.BED;
        m_dialogDisplayer.SetDialog(m_dialogPlayer);
    }

    private void playMonsterDialog()
    {
        m_dialogDisplayer.SetDialog(m_dialogMonster);
        end = true;
    }

    IEnumerator FadeImage(bool fadeAway, bool chara, bool ischara)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 2 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime/2)
            {
                // set color with i as alpha
                image.color = new Color(0, 0, 0, i);
                yield return null;
            }
            go_monster = true;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 2 second
            for (float i = 0; i <= 1; i += Time.deltaTime/2)
            {
                // set color with i as alpha
                image.color = new Color(0, 0, 0, i);
                yield return null;
            }
            if (ischara)
            {
                choose_dialog(chara);
            }
        }
    }


    void choose_dialog(bool chara) {
        if (chara)
        {
            if (!first_dial)
            {
                playCharaDialog();
                first_dial = true;
            }
        }
        else {
            if (!second_dial)
            {
                playMonsterDialog();
                second_dial = true;
            }
        }
    }
}

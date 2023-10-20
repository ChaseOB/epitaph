using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogLogic : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;

    public Image characterComponenet;
    public string[] lines;
    public string[] namesPerLine;
    public List<Sprite> Sprites;
    public float textSpeed;
    private int index;

    StartConvo StartConvoScript;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
        nameComponent.text = string.Empty;
        StartConvoScript = GameObject.FindGameObjectWithTag("NPC").GetComponent<StartConvo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index]){
                nextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialog(){
        index=0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        nameComponent.text = namesPerLine[index];
        characterComponenet.sprite = Sprites[index];
    }

    IEnumerator TypeLine(){
        // type one by one
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text +=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine(){
        if (index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            nameComponent.text = namesPerLine[index];
            characterComponenet.sprite = Sprites[index];
        }
        else
        {
            gameObject.SetActive(false);
            textComponent.text = string.Empty;
            nameComponent.text = string.Empty;
            StartConvoScript.EnableKey();

        }
    }
}

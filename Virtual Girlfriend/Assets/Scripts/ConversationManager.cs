using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoSingleton<ConversationManager>
{
    public delegate string GirlAnswer();
    public event GirlAnswer OnPlayerAnswered;

    public string trrr;

    [SerializeField]
    private GameObject dialogueContainer;

    [SerializeField]
    private GameObject boyTextPrefab;
    public GameObject BoyTextPrefab
    {
        get
        {
            return boyTextPrefab;
        }
    }

    [SerializeField]
    private GameObject girlTextPrefab;
    public GameObject GirlTextPrefab
    {
        get
        {
            return girlTextPrefab;
        }
    }



    private List<TMP_Text> texts;

    private List<TMP_Text> playerTexts;

    private List<TMP_Text> GirlTexts;

    private List<RectTransform> rectsofTexts;

    private float nextYPosition = 0;

    [SerializeField]
    private int maxChar;

    bool isSecondLine = false;
    bool isLastLine = false;
    public string text;


    public string[] onebigfile;
    // Start is called before the first frame update
    // Update is called once per frame

    public void SendInstantnlyBoyMessage(string text)
    {
        string firstline = text;
        if (text.ToCharArray().Length > maxChar)
        {
            isSecondLine = true;
            firstline = text.Substring(0, maxChar - 1);
            text = text.Substring(maxChar);
            SendInstantnlyBoyMessage(text);
        }
        else
        {
            isLastLine = true;
        }

        GameObject go = ObjectPooler.Instance.SpawnFromPool("BoyText", new Vector3(boyTextPrefab.transform.localPosition.x, boyTextPrefab.transform.localPosition.y + nextYPosition, boyTextPrefab.transform.localPosition.z), Quaternion.identity, null);
        go.transform.SetParent(dialogueContainer.transform, false);


        TMP_Text message = go.GetComponent<TMP_Text>();
        message.text = firstline;

        if (isSecondLine)
        {
            message.alignment = TextAlignmentOptions.Left;

        }
        go.transform.SetParent(dialogueContainer.transform, false);
        nextYPosition += 34;
        isSecondLine = false;

        GirlfriendAI.Instance.StateMachine.CurrentState.DoEmotionMath(text);
        if (isLastLine)
        {
            StartCoroutine(StartGirlAnswer(GirlfriendAI.Instance.StateMachine.CurrentState.DoStringMath(text)));
        }
    }
    public IEnumerator StartGirlAnswer(string text1)
    {

        GameObject go = ObjectPooler.Instance.SpawnFromPool("GirlText", new Vector3(girlTextPrefab.transform.localPosition.x, girlTextPrefab.transform.localPosition.y + nextYPosition, girlTextPrefab.transform.localPosition.z), Quaternion.identity, null);
        TMP_Text message = go.GetComponent<TMP_Text>();
        
        text = string.Empty;
        go.transform.SetParent(dialogueContainer.transform, false);

        for (int i = 0; i < 2; i++)
        {
            float t = 0;
            text = string.Empty;

            while (t<3)
            {
                t += 1;
                text += ".";
                message.text = text;
                yield return new WaitForSeconds(0.3f);
            }
        }

        string firstline = text1;
        if (text1.ToCharArray().Length > maxChar)
        {
            isSecondLine = true;
            firstline = text1.Substring(0, maxChar - 1);
            text1 = text1.Substring(maxChar -1);
        }
        else
        {
            isLastLine = true;
        }


        message.text = text1;

      
        go.transform.SetParent(dialogueContainer.transform, false);
        nextYPosition += 34;
        if (isSecondLine)
        {
            message.alignment = TextAlignmentOptions.Left;
            SendInstantlyGirlMessage(firstline);
        }
        isSecondLine = false;
    }
    //public void SendInstantlyBoyMessage(string text)
    //{
    //    string firstline = text;
    //    if(text.ToCharArray().Length > maxChar)
    //    {
    //        isSecondLine = true;
    //        firstline = text.Substring(0, maxChar-1);
    //        text = text.Substring(maxChar);
    //        SendInstantlyBoyMessage(text);
            
    //    }

    //    GameObject go = Instantiate(boyTextPrefab, new Vector3(boyTextPrefab.transform.localPosition.x, boyTextPrefab.transform.localPosition.y + nextYPosition, boyTextPrefab.transform.localPosition.z), Quaternion.identity);

    //    TMP_Text message = go.GetComponent<TMP_Text>();
    //    message.text = firstline;

    //    if (isSecondLine)
    //    {
    //        message.alignment = TextAlignmentOptions.Left;

    //    }
    //    go.transform.SetParent(dialogueContainer.transform, false);
    //    nextYPosition += 34;
    //    isSecondLine = false;
    //    float t = LayoutUtility.GetPreferredWidth(message.rectTransform);
    //    RectTransform rect = go.GetComponent<RectTransform>();
    //    Debug.Log(t);

    //}

    public void SendInstantlyGirlMessage(string text)
    {
        string firstline = text;
        if (text.ToCharArray().Length > maxChar)
        {
            isSecondLine = true;
            firstline = text.Substring(0, maxChar - 1);
            text = text.Substring(maxChar);
            SendInstantlyGirlMessage(text);
        }
        else
        {
            isLastLine = true;
        }

        GameObject go = ObjectPooler.Instance.SpawnFromPool("GirlText", new Vector3(girlTextPrefab.transform.localPosition.x, girlTextPrefab.transform.localPosition.y + nextYPosition, girlTextPrefab.transform.localPosition.z), Quaternion.identity, null);
        TMP_Text message = go.GetComponent<TMP_Text>();

        go.transform.SetParent(dialogueContainer.transform, false);

        message.text = firstline;

        if (isSecondLine)
        {
            message.alignment = TextAlignmentOptions.Left;
        }

        nextYPosition += 34;
        isSecondLine = false;
        isLastLine = false;
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationManager : MonoBehaviour
{
    public NPCConversation npc;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        DialogueEditor.ConversationManager.Instance.StartConversation(npc);
    }
   
}

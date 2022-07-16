using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PlayerConversation : MonoBehaviour
{
    public NPCConversation npc;

    void Start()
    {

        DialogueEditor.ConversationManager.Instance.StartConversation(npc);

    }
}

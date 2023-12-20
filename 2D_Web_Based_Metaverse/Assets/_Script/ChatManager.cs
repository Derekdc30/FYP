using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public Button button;
    public Color playerMessage, info;


    // Start is called before the first frame update
    void Start()
    {
        // Add listener to button
        button.onClick.AddListener(SendText);

        // Add listener to input field
        chatBox.onEndEdit.AddListener(delegate { SendText(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

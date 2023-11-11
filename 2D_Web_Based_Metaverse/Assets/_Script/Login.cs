using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{

    public GameObject usernameInput;
    public GameObject passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;
    public TextAsset jsonFile;

    UserDatabase userDatabase;
    UserData userData;

    [System.Serializable]
    public class UserData{
        public string username;
        public string password;
    }

        [System.Serializable]
    public class UserDatabase{
        public UserData[] users;
    }

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(login);
        goToRegisterButton.onClick.AddListener(moveToRegister);
        userDatabase = JsonUtility.FromJson<UserDatabase>(jsonFile.text);
    }



    // Update is called once per frame
    void login()
    {
        string username = usernameInput.GetComponent<TMP_InputField>().text;
        string password = passwordInput.GetComponent<TMP_InputField>().text;
        if(ValidateUser(username,password)){
            loadMainScene();
        }
        else{
            Debug.Log("Error");
        }
    }

    void moveToRegister()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    void loadMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public bool ValidateUser(string UserName, string Password){
        foreach(UserData userData in userDatabase.users){
            if(userData.username == UserName && userData.password == Password){
                return true;
            }
        }
        return false;
    }
}

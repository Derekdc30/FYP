using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Register : MonoBehaviour
{
    public GameObject usernameInput;
    public GameObject passwordInput;
    public GameObject Re_passwordInput;
    public Button registerButton;
    public Button goToLoginButton;
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
        goToLoginButton.onClick.AddListener(moveTologin);
        registerButton.onClick.AddListener(register);
        userDatabase = JsonUtility.FromJson<UserDatabase>(jsonFile.text);
    }

    void moveTologin(){
        SceneManager.LoadScene("LoginScene");
    }
    void register(){
        string username = usernameInput.GetComponent<TMP_InputField>().text;
        string password = passwordInput.GetComponent<TMP_InputField>().text;
        string re_password = Re_passwordInput.GetComponent<TMP_InputField>().text;
        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(re_password)){
            Debug.Log("Empty field"); //action on empty field
        }
        else{
            if(UserExists(username)){
                Debug.Log("User Exist"); //action on user name already exist
            }
            else{
                if(password == re_password){
                    Debug.Log("Register success"); //action on successfully register
                    UserData newUser = new UserData
                    {
                        username = username,
                        password = password
                    };
                    Array.Resize(ref userDatabase.users, userDatabase.users.Length + 1);
                    userDatabase.users[userDatabase.users.Length - 1] = newUser;

                    // Save the updated user database to the JSON file
                    SaveUserDatabaseToJson();
                }
                else{
                    Debug.Log("password not match"); //action on password not match
                }
            }
        }

        
    }
    public bool UserExists(string UserName)
    {
        foreach(UserData userData in userDatabase.users){
            if(userData.username == UserName){
                return true;
            }
        }
        return false;
    }
    void SaveUserDatabaseToJson()
    {
        string jsonPath = Application.dataPath + "/Json/user.json";
        string updatedJsonData = JsonUtility.ToJson(userDatabase);
        File.WriteAllText(jsonPath, updatedJsonData);
    }
}

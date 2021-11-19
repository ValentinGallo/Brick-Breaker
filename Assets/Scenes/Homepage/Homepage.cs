using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Homepage : MonoBehaviour
{
    public InputField InputPseudonyme;
    public Text TxtErreurPseudonyme;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void NewGame() {
        InputField inputPseudonyme = GameObject.Find("InputPseudonyme").GetComponent<InputField>();
        string pseudonyme = inputPseudonyme.text;

        if(pseudonyme.Length > 0) {
            PlayerPrefs.SetString("pseudonyme", pseudonyme);
            PlayerPrefs.DeleteKey("score");
            PlayerPrefs.DeleteKey("classement");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        } else {
            Text txtErreurPseudonyme = GameObject.Find("TxtErreurPseudonyme").GetComponent<Text>(); 
            txtErreurPseudonyme.text = "Veuillez entrer un pseudonyme pour lancer une partie !";
        }
	}

	public void LeaveGame() {
        Application.Quit();
	}    
}

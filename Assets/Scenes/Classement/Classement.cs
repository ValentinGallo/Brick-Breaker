using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Classement : MonoBehaviour
{
    public Text txtClassementPremier;
    public Text txtClassementSecond;
    public Text txtClassementTroisieme;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        SetClassement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {
        PlayerPrefs.DeleteKey("classement");
        PlayerPrefs.DeleteKey("score");
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
	}

	public void LeaveGame() {
        Application.Quit();
	}

        // Permet d'établir le Top 3 des joueurs
    public void SetClassement() {
        string[] tableauClassement = GetClassement();

        string nomJoueur1 = "";
        string nomJoueur2 = "";
        string nomJoueur3 = "";

        int scoreJoueur1 = 0;
        int scoreJoueur2 = 0;
        int scoreJoueur3 = 0;

        // Deformat le fichier pour comprendre le classement
        int i = 1;
        
        foreach (string infosJoueur in tableauClassement)
        {
            string[] infosJoueurSplit = infosJoueur.Split(","[0]);

            if(infosJoueurSplit.Length > 1) {
                string nomJoueur = infosJoueurSplit[0];
                int scoreJoueur = int.Parse(infosJoueurSplit[1]);

                switch (i)
                {
                    case 1:
                        nomJoueur1 = nomJoueur;
                        scoreJoueur1 = scoreJoueur;                 
                        break;
                    case 2:
                        nomJoueur2 = nomJoueur;
                        scoreJoueur2 = scoreJoueur;       
                        break;
                    case 3:
                        nomJoueur3 = nomJoueur;
                        scoreJoueur3 = scoreJoueur;                 
                        break;
                    default:
                        break;
                }
            }
            i++;
        }
        
        // Affiche dans le menu Game Over le TOP 3
        txtClassementPremier = GameObject.Find("txtClassementPremier").GetComponent<Text>(); 
        txtClassementPremier.text = "1 - " + nomJoueur1 + " | " + scoreJoueur1 + " Points";

        txtClassementSecond = GameObject.Find("txtClassementSecond").GetComponent<Text>(); 
        txtClassementSecond.text = "2 - " + nomJoueur2 + " | " + scoreJoueur2 + " Points";

        txtClassementTroisieme = GameObject.Find("txtClassementTroisieme").GetComponent<Text>(); 
        txtClassementTroisieme.text = "3 - " + nomJoueur3 + " | " + scoreJoueur3 + " Points";
    }

    // Permet d'obtenir le Top 3 des joueurs
    public string[] GetClassement() {
        string path = Application.persistentDataPath + "/classement.txt";

        if (!(System.IO.File.Exists(path)))
        {
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("");
            writer.Close();
        }

        StreamReader reader = new StreamReader(path);
        string classementReader = reader.ReadToEnd();
        reader.Close();

        string[] classement = classementReader.Split("/"[0]);
        return classement;
    }
}

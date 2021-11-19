using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text txtScore;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        if (PlayerPrefs.HasKey("score") && !PlayerPrefs.HasKey("classement"))
        {
            txtScore = GameObject.Find("txtScore").GetComponent<Text>(); 
            txtScore.text = "Score: " + PlayerPrefs.GetInt("score");

            SetClassement(PlayerPrefs.GetString("pseudonyme"), PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
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

	public void Classement() {
        PlayerPrefs.DeleteKey("classement");
        PlayerPrefs.DeleteKey("score");
        SceneManager.LoadScene("Classement", LoadSceneMode.Single);
	}

	public void LeaveGame() {
        Application.Quit();
	}

    // Permet d'établir le Top 3 des joueurs
    public void SetClassement(string nom, int score) {
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

        // Permet d'établir le classement de notre joueur dans le top 3 
        if(score > scoreJoueur1) {
            nomJoueur3 = nomJoueur2;
            scoreJoueur3 = scoreJoueur2;

            nomJoueur2 = nomJoueur1;
            scoreJoueur2 = scoreJoueur1;

            nomJoueur1 = nom;
            scoreJoueur1 = score;
        } else if (score > scoreJoueur2 && score <= scoreJoueur1) {
            nomJoueur3 = nomJoueur2;
            scoreJoueur3 = scoreJoueur2;

            nomJoueur2 = nom;
            scoreJoueur2 = score;
        } else if (score > scoreJoueur3 && score <= scoreJoueur2) {
            nomJoueur3 = nom;
            scoreJoueur3 = score;
        }

        // Reformat le classement pour le fichier
        string[] classement = new string[] {nomJoueur1 + "," + scoreJoueur1, nomJoueur2 + "," + scoreJoueur2, nomJoueur3 + "," + scoreJoueur3};
        string classementString = "";
        i = 1 ;
        foreach (string joueur in classement)
        {
            if(i<=classement.Length-1) {
                classementString = classementString + joueur + "/";
            } else {
                classementString = classementString + joueur;
            }

            i++;
        }
        
        SaveClassement(classementString);
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

    // Permet de sauvegarder le Top 3 des joueurs
    public void SaveClassement(string classement) {
        string path = Application.persistentDataPath + "/classement.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(classement);
        writer.Close();

        PlayerPrefs.SetString("classement", "true");
    }
}

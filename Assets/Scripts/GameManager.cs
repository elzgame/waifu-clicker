using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text newWaifuText;
    public static AudioSource source;
    public int[] scoreToChangeCharacter;
    public GameObject[] characterPrefab;
    private int currentIndexCharacter;
    public Transform characterSpawnPoint;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        scoreText.text = "Score : " + GameManager.score.ToString();
        GameObject checkGameObject = GameObject.FindGameObjectWithTag("Player");
        if (characterPrefab[currentIndexCharacter + 1] != null)
        {
            newWaifuText.text = "Waifu Baru di Score : " + scoreToChangeCharacter[currentIndexCharacter + 1];
            if (score >= scoreToChangeCharacter[currentIndexCharacter + 1])
            {
                Destroy(checkGameObject);
                currentIndexCharacter++;
                Debug.Log("Change Character to : " + characterPrefab[currentIndexCharacter].gameObject.name);
            }
        }
        else
        {
            Debug.Log("Tidak ada karakter lagi!");
            newWaifuText.text = "Waifu telah habis :)";
        }

        if (checkGameObject != null)
        {
            Debug.Log("Sudah tersedia karakter, nama : " + checkGameObject.transform.name);
        }
        else
        {
            if (score == scoreToChangeCharacter[currentIndexCharacter])
            {
                GameObject character = Instantiate(characterPrefab[currentIndexCharacter], characterSpawnPoint.position, characterSpawnPoint.rotation);
                string characterName = character.transform.name.Remove(character.transform.name.IndexOf("(Clone)"));
                character.transform.SetParent(characterSpawnPoint);
                character.transform.name = characterName;
            }
        }
    }

    public void Donasi()
    {
        Application.OpenURL("https://saweria.co/suryaelidanto");
    }
}

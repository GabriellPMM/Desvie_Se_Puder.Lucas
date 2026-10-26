using System;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
        
    public float velocidadeDoJogador;
    public Animator oAnimador;
    public int quantidadeDeMoedas;
    public Text textoDasMoedasAtuais;
    public GameObject painelDeGameOver;
    public Text textoDePontuacao; 
    public Text textoDeHighScore;

    
    void Start()
    {
        oAnimador = GetComponent<Animator>();
        quantidadeDeMoedas = 0;
        textoDasMoedasAtuais.text = "x" + quantidadeDeMoedas;
    }

    void Update()
    {
        MovimentarJogador();
    }

    public void MovimentarJogador()
    { 
        float comandosDoTeclado = Input.GetAxisRaw("Horizontal") * velocidadeDoJogador * Time.deltaTime;
        transform.position = new Vector3((transform.position.x + comandosDoTeclado), transform.position.y,
        transform.position.z);

        // Personagem vira para a DIREITA
        if(comandosDoTeclado > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        // Personagem vira para a ESQUERDA
        if(comandosDoTeclado < -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        // Ativa/Desativa as Animações "ANDANDO" E "PARADO"
        if(comandosDoTeclado == 0)
        {
            oAnimador.Play("Player_Parado");
        }
        else
        {
            oAnimador.Play("Player_Andando");
        }

    }


    public void AumentarQuantidadeDeMoedas()
    {
        quantidadeDeMoedas =+ 1;
        textoDasMoedasAtuais.text = "x" + quantidadeDeMoedas;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        painelDeGameOver.SetActive(true);
        textoDePontuacao.text = "PONTUAÇÃO: " + quantidadeDeMoedas; 
        Debug.Log("Game Over");

        if(quantidadeDeMoedas > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.GetInt("HighScore", quantidadeDeMoedas);
        }
        textoDeHighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HIGHSCORE");
    }
}

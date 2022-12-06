using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Objeto;
    public string Nome;
    public int Numero;
    public float LeFloat;
    public Bow Arco;
    public ArrowStatic StaticArrow;
    public ArrowProjectile ArrowProjectile;
    public MeshRenderer Meshi;

    public Target Target1;
    public Target Target2;
    public Target Target3;
    public Target Target4;
    private List<Target> TargetList = new List<Target>();
    private List<string> QuestionList = new List<string>();
    private List<int> AnswerList = new List<int>();

    public QuestionBoard QuestionBoard;

    private int CurrentQuestion;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        var arco = Meshi.gameObject.GetComponent<Bow>();

        TargetList.Add(Target1);
        TargetList.Add(Target2);
        TargetList.Add(Target3);
        TargetList.Add(Target4);

        QuestionList.Add("Um terreno retangular será dividido ao meio, pela sua diagonal, formando dois triângulos retângulos.A metade desse terreno será cercada com 4 fios de arame farpado.Sabendo que as dimensões desse terreno são de 20 metros de largura e 21 metros de comprimento, qual será a metragem mínima gasta de arame ?");

        StartGame();

        CurrentQuestion += 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool IsPressingF = Input.GetKey(KeyCode.F);
        bool IsFKeyUp = Input.GetKeyUp(KeyCode.F);
        bool IsFKeyDown = Input.GetKeyDown(KeyCode.F);

        if (IsPressingF)
        {
            Arco.Distort();
            StaticArrow.AdjustPush();
        }
        else
        {
            Arco.Undistort();
            StaticArrow.AdjustIdle();
        }

        if (IsFKeyUp)
        {
            StaticArrow.Hide();
            ArrowProjectile.Shoot();
        }
    }

    private void StartGame()
    {
        // reset targets
        Target1.answer = "teste1";
        Target2.answer = "teste2";
        Target3.answer = "teste3";
        Target4.answer = "teste4";
        Target1.isRightTarget = false;
        Target2.isRightTarget = false;
        Target3.isRightTarget = false;
        Target4.isRightTarget = false;


        int rand = Random.Range(0, 3);

        TargetList[rand].answer = "deu certo crlh";
    }

    public void RightAnswer()
    {

    }

    public void WrongAnswer()
    {

    }
}

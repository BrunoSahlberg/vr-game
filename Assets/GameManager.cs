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

    [SerializeField] GameObject _bow;
    [SerializeField] GameObject _arrow;
    [SerializeField] GameObject _tipPai;
    [SerializeField] GameObject _tip;
    [SerializeField] GameObject _tipPaiEraser;
    [SerializeField] GameObject _tipEraser;


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
        var arco = Meshi.gameObject.GetComponent<Bow>();

        CurrentQuestion += 0;

        TargetList.Add(Target1);
        TargetList.Add(Target2);
        TargetList.Add(Target3);
        TargetList.Add(Target4);

        QuestionList.Add("Um terreno retangular ser� dividido ao meio, pela sua diagonal, formando dois tri�ngulos ret�ngulos.A metade desse terreno ser� cercada com 4 fios de arame farpado.Sabendo que as dimens�es desse terreno s�o de 20 metros de largura e 21 metros de comprimento, qual ser� a metragem m�nima gasta de arame ?");
        QuestionList.Add("Um tri�ngulo de altura X, hipot�nusa 13cm e base 5cm, encontre a �rea do tri�ngulo");
        QuestionList.Add("Dado um ret�ngulo de base 40m e altura 30m, qual o seu di�metro?");
        QuestionList.Add("Qual � a quantidade de arranjos simples que podemos fazer utilizando 3 letras do conjunto {A, B, C, D, E}?");

        AnswerList.Add(280);
        AnswerList.Add(30);
        AnswerList.Add(50);
        AnswerList.Add(60);

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsPressingF = Input.GetKey(KeyCode.F);
        bool IsFKeyUp = Input.GetKeyUp(KeyCode.F);
        bool IsFKeyDown = Input.GetKeyDown(KeyCode.F);
        bool IsEquipedBowKeyPressed = Input.GetKeyDown(KeyCode.Alpha1);
        bool IsEquipedPenKeyPressed = Input.GetKeyDown(KeyCode.Alpha2);
        bool IsEquipedEraserKeyPressed = Input.GetKeyDown(KeyCode.Alpha3);

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

        if (IsEquipedBowKeyPressed)
        {
            _bow.SetActive(true);
            _arrow.SetActive(true);
            _tipPai.SetActive(false);
            _tipPaiEraser.SetActive(false);
        }

        if (IsEquipedPenKeyPressed)
        {
            _bow.SetActive(false);
            _arrow.SetActive(false);
            _tipPai.SetActive(true);
            _tipPaiEraser.SetActive(false);
        }

        if (IsEquipedEraserKeyPressed)
        {
            _bow.SetActive(false);
            _arrow.SetActive(false);
            _tipPai.SetActive(false);
            _tipPaiEraser.SetActive(true);
        }

    }

    private void StartGame()
    {
        ResetTargets();
        EnableTargets();

        int randTarget = Random.Range(0, 3);
        TargetList[randTarget].isRightTarget = true;
        TargetList[randTarget].answer = AnswerList[CurrentQuestion];

        QuestionBoard.UpdateQuestion(QuestionList[CurrentQuestion]);

        SetWrongQuestions(randTarget);

        CurrentQuestion++;
    }

    public void RightAnswer()
    {
        NextQuestion();
    }

    public void WrongAnswer()
    {
        // TO DO: Erros
    }

    private void NextQuestion()
    {
        ResetTargets();

        int randTarget = Random.Range(0, 3);
        TargetList[randTarget].isRightTarget = true;
        TargetList[randTarget].answer = AnswerList[CurrentQuestion];

        QuestionBoard.UpdateQuestion(QuestionList[CurrentQuestion]);

        SetWrongQuestions(randTarget);

        CurrentQuestion++;
        if (CurrentQuestion == 4)
        {
            DisableTargets();
            // TO DO: End Game
        }
    }

    private void ResetTargets()
    {
        Target1.answer = 0;
        Target2.answer = 0;
        Target3.answer = 0;
        Target4.answer = 0;
        Target1.isRightTarget = false;
        Target2.isRightTarget = false;
        Target3.isRightTarget = false;
        Target4.isRightTarget = false;
    }

    private void SetWrongQuestions(int selectedTarget) 
    {
        for (int index = 0; index <= 3; index++)
        {
            if (index != selectedTarget)
            {
                int randAnswer = AnswerList[CurrentQuestion];
                while (randAnswer == AnswerList[CurrentQuestion])
                {
                    randAnswer = Random.Range((AnswerList[CurrentQuestion] - 15), (AnswerList[CurrentQuestion] + 15));
                }

                TargetList[index].answer = randAnswer;
            }
        }
    }

    private void DisableTargets()
    {
        Target1.IsDisabled = true;
        Target2.IsDisabled = true;
        Target3.IsDisabled = true;
        Target4.IsDisabled = true;
    }

    private void EnableTargets()
    {
        Target1.IsDisabled = false;
        Target2.IsDisabled = false;
        Target3.IsDisabled = false;
        Target4.IsDisabled = false;
    }
}

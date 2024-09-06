using Gwent_Compiler;
using Gwent_Compiler.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCard : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFields;
    [SerializeField] private SceneManager compilerScene;

    public void CreateInfoCard()
    {
        //try
        //{
            SyntaxTree syntaxTree = SyntaxTree.Parse(inputFields.text);
            InformationGenerator.CreateCard(syntaxTree);
        //    print(syntaxTree.ReadParse()[0].Power);
        //    print(syntaxTree.ReadParse()[0].Faction);
        //    print(syntaxTree.ReadParse()[0].Range[0]);
        //    print(syntaxTree.ReadParse()[0].Range[1]);
        //    print(syntaxTree.ReadParse()[0].Range[2]);
        //    //print(syntaxTree.ReadParse()[0].Effects[0].ToString());
        //    //print(syntaxTree.ReadParse()[0].Type);
        //    //Effect effect = (Effect)syntaxTree.root.First();
        //    //ForExpression forExpression = (ForExpression)effect.Action.LambdaExpression.StatementAction.Expressions.First();
        //    //WhileExpression whileExpression = (WhileExpression)forExpression.ForStatement.Expressions.Skip(1).First();
        //    //print(whileExpression.WhileStatement.Expressions.First());

        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e.Message);
        //    return;
        //}

        GameObject compiler = gameObject.transform.parent.gameObject;
        GameObject Presentation = compiler.transform.parent.GetChild(1).gameObject;

        print(compiler);
        print(Presentation);

        Presentation.SetActive(true);

    }
    public void AccessOfCompilerScene()
    {
        SceneManager.LoadSceneAsync("Compiler");
        SceneManager.UnloadSceneAsync("StartScene");
    }
}

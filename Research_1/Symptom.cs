
using System.Collections.Generic;
using UnityEngine;

public class Symptom 
{
    public int Id { get; }
    public string Name { get; }

    private List<int> AnswersManifest;

    public Symptom(int Id, string Name, List<int> AnswersManifest)
    {
        this.Id = Id;
        this.Name = Name;
        this.AnswersManifest = AnswersManifest;
    }

    public Answer getAnswer()
    {

        //случайно выбираем ответ из списка возможных
        int answerCode = AnswersManifest[Random.Range(0, AnswersManifest.Count-1)];
        //из конфигурационного файла считываем информацию
        //про ответ с Id равным answerCode и создаем объект Answer 
        //возвращаем этот объект
        return null;
    }

    ~Symptom()
    {
        AnswersManifest.Clear();
    }



}

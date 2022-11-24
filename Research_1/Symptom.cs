
using System;
using System.Collections.Generic;

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
        Random rand = new Random();
        //случайно выбираем ответ из списка возможных
        int answerCode = AnswersManifest[rand.Next(0, AnswersManifest.Count-1)];
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

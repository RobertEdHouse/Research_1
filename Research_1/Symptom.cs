
using System;
using System.Collections.Generic;

[Serializable]
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
        int answerCode = AnswersManifest[rand.Next(0, AnswersManifest.Count)];
        Answer answer = loadAnswer(answerCode);
        //из конфигурационного файла считываем информацию
        //про ответ с Id равным answerCode и создаем объект Answer 
        //возвращаем этот объект
        return answer;
    }

    ~Symptom()
    {
        AnswersManifest.Clear();
    }

    private Answer loadAnswer(int code)
    {
        List<Answer> answers = new List<Answer>();
        answers.Add(new Answer(0, "Голова така важка"));
        answers.Add(new Answer(1, "Такi болi в головi"));
        answers.Add(new Answer(2, "Нудить цiлий день"));
        answers.Add(new Answer(3, "Живот болить"));
        answers.Add(new Answer(4, "Немає сил"));
        answers.Add(new Answer(5, "Не можу встати з лiжка"));

        foreach(Answer a in answers){
            if (a.Id == code)
                return a;
        }
        return null;
    }




}


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
        //�������� �������� ����� �� ������ ���������
        int answerCode = AnswersManifest[rand.Next(0, AnswersManifest.Count)];
        Answer answer = loadAnswer(answerCode);
        //�� ����������������� ����� ��������� ����������
        //��� ����� � Id ������ answerCode � ������� ������ Answer 
        //���������� ���� ������
        return answer;
    }

    ~Symptom()
    {
        AnswersManifest.Clear();
    }

    private Answer loadAnswer(int code)
    {
        List<Answer> answers = new List<Answer>();
        answers.Add(new Answer(0, "������ ���� �����"));
        answers.Add(new Answer(1, "���i ���i � �����i"));
        answers.Add(new Answer(2, "������ �i��� ����"));
        answers.Add(new Answer(3, "����� ������"));
        answers.Add(new Answer(4, "���� ���"));
        answers.Add(new Answer(5, "�� ���� ������ � �i���"));

        foreach(Answer a in answers){
            if (a.Id == code)
                return a;
        }
        return null;
    }




}


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
        //�������� �������� ����� �� ������ ���������
        int answerCode = AnswersManifest[rand.Next(0, AnswersManifest.Count-1)];
        //�� ����������������� ����� ��������� ����������
        //��� ����� � Id ������ answerCode � ������� ������ Answer 
        //���������� ���� ������
        return null;
    }

    ~Symptom()
    {
        AnswersManifest.Clear();
    }



}

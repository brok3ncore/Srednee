using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = 80;   
        int M = 4;    
        int RB = 1;   
        int RE = 5;   

        Random rnd = new Random();
        List<(int group, int mark)> grades = new List<(int, int)>();
        for (int i = 0; i < N; i++)
        {
            int group = rnd.Next(1, M + 1);
            int mark = rnd.Next(RB, RE + 1);
            grades.Add((group, mark));
        }
        List<int>[] groupMarks = new List<int>[M];
        for (int i = 0; i < M; i++)
            groupMarks[i] = new List<int>();

        foreach (var g in grades)
            groupMarks[g.group - 1].Add(g.mark);
        Console.WriteLine("Группа\tКол-во\tСредняя\tОценки");

        double totalSum = 0;
        int totalCount = 0;

        for (int i = 0; i < M; i++)
        {
            int count = groupMarks[i].Count;
            double avg = count > 0 ? groupMarks[i].Average() : 0;

            totalSum += groupMarks[i].Sum();
            totalCount += count;

            Console.Write($"{i + 1}\t{count}\t{avg:F2}\t");
            foreach (int mark in groupMarks[i])
                Console.Write(mark + " ");
            Console.WriteLine();
        }

        double overallAverage = totalCount > 0 ? totalSum / totalCount : 0;
        Console.WriteLine($"\nСредняя по всем студентам: {overallAverage:F2}");
    }
}

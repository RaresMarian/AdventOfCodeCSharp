namespace AdventOfCode.Day02;

public class Day02Tests
{
    private readonly ITestOutputHelper _output;
    public Day02Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day02Solver().ExecuteExample1("??");
        
    [Fact] public void Step2WithExample() => new Day02Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day02Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day02Solver().ExecutePuzzle2());
}

public class Day02Solver : SolverBase
{
    private List<List<int>> _reports = new();


    protected override void Parse(List<string> data)  
    {
        _reports = data
        .Where(line => !string.IsNullOrWhiteSpace(line)) // ignora righe vuote
        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries) // rimuove stringhe vuote
                            .Select(int.Parse)
                            .ToList())
        .ToList();
        



    }

    protected override object Solve1()
    {

        int safeCount = 0;

        foreach (var report in _reports)
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < report.Count; i++)
            {
                int diff = report[i] - report[i - 1];

                if (diff < 1 || diff > 3)
                {
                    increasing = decreasing = false;
                    break;
                }

                if (diff > 0)
                    decreasing = false;
                else if (diff < 0)
                    increasing = false;
            }

            if (increasing || decreasing)
                safeCount++;
        }

        return safeCount;
    }

    protected override object Solve2()
    {
        return Solve1();
        
    }
}

namespace AdventOfCode.Day01;

public class Day01Tests
{
    private readonly ITestOutputHelper _output;
    public Day01Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day01Solver().ExecuteExample1("??");

    [Fact] public void Step2WithExample() => new Day01Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day01Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day01Solver().ExecutePuzzle2());
}

public class Day01Solver : SolverBase
{
    private List<int> _left;
    private List<int> _right;

    protected override void Parse(List<string> data)
    {
        _left = data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
        _right = data[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToList();
    }

    protected override object Solve1()
    {
        // Ordina le liste e calcola la somma delle differenze assolute
        var leftSorted = _left.OrderBy(n => n).ToList();
        var rightSorted = _right.OrderBy(n => n).ToList();

        int distance = 0;
        for (int i = 0; i < leftSorted.Count; i++)
        {
            distance += Math.Abs(leftSorted[i] - rightSorted[i]);
        }

        
        return distance;
        
    }

    protected override object Solve2()
    {
        return Solve1().ToString();
    }
}

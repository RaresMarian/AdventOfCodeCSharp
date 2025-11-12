namespace AdventOfCode.Day05;

public class Day05Tests
{
    private readonly ITestOutputHelper _output;
    public Day05Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day05Solver().ExecuteExample1("??");
        
    [Fact] public void Step2WithExample() => new Day05Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day05Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day05Solver().ExecutePuzzle2());
}

public class Day05Solver : SolverBase
{
    private List<(int X, int Y)> _rules = new();
    private List<List<int>> _updates = new();

    protected override void Parse(List<string> data)
    {
        // Dividiamo input in regole e aggiornamenti
        var emptyIndex = data.IndexOf("");
        var rulesInput = data.Take(emptyIndex).ToList();
        var updatesInput = data.Skip(emptyIndex + 1).ToList();

        foreach (var line in rulesInput)
        {
            var parts = line.Split('|');
            _rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
        }

        foreach (var line in updatesInput)
        {
            var pages = line.Split(',').Select(int.Parse).ToList();
            _updates.Add(pages);
        }
    }

    protected override object Solve1()
    {
        int sumMiddlePages = 0;

        foreach (var update in _updates)
        {
            bool valid = true;

            foreach (var (x, y) in _rules)
            {
                if (update.Contains(x) && update.Contains(y))
                {
                    if (update.IndexOf(x) > update.IndexOf(y))
                    {
                        valid = false;
                        break;
                    }
                }
            }

            if (valid)
            {
                int middleIndex = update.Count / 2;
                sumMiddlePages += update[middleIndex];
            }
        }

        return sumMiddlePages;
    }

    protected override object Solve2()
    {
        throw new NotImplementedException();
    }
}


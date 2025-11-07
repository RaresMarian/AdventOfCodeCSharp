using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Day03;

public class Day03Tests
{
    private readonly ITestOutputHelper _output;
    public Day03Tests(ITestOutputHelper output) => _output = output;

    [Fact] public void Step1WithExample() => new Day03Solver().ExecuteExample1("??");
        
    [Fact] public void Step2WithExample() => new Day03Solver().ExecuteExample2("??");

    [Fact] public void Step1WithPuzzleInput() => _output.WriteLine(new Day03Solver().ExecutePuzzle1());
        
    [Fact] public void Step2WithPuzzleInput() => _output.WriteLine(new Day03Solver().ExecutePuzzle2());
}

public class Day03Solver : SolverBase
{
    private List<string> _lines = new();

    protected override void Parse(List<string> data)
    {
        _lines = data;
        

    }

    protected override object Solve1()
    {
        // Regex per trovare solo i mul(X,Y) validi
        Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

        int sommaTotale = 0;


        foreach (var line in _lines)
        {
            // Trova tutte le corrispondenze
            MatchCollection matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sommaTotale += x * y;
            }
        }
        return sommaTotale;


    }

    protected override object Solve2()
    {
        return Solve1();
    }
}

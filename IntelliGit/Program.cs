using Fclp;

namespace IntelliGit;

class Program
{
    static void Main(string[] args)
    {
        var parser = new FluentCommandLineParser<IntelliGitArguments>();
        parser.Setup(arg => arg.Staged)
            .As('s', "staged")
            .Required();
        parser.Setup(arg => arg.NumberOfEstimatedCommits)
            .As('c', "num")
            .Required();

        var programArgs = parser.Parse(args);
    }
}
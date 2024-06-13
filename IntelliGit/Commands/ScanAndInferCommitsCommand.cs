using Domain.Interfaces;
using DotMake.CommandLine;
using LibGit2Sharp;

namespace IntelliGit;

[CliCommand(Description = "")]
public class ScanAndInferCommitsCommand
{
    [CliOption(Description = "Only scan staged files.")]
    public bool Staged { get; set; }
    
    [CliOption(Description = "Number of commits to infer.")]
    public int NumberOfEstimatedCommits { get; set; }
    
    
    public void Run()
    {
        
    }
}

public class IntelliGitCommand(string repositoryPath)
{
    protected Repository Repository { get; } = new(repositoryPath);
}
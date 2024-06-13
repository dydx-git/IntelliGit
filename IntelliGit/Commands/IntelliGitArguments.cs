using LibGit2Sharp;

namespace IntelliGit;

public record IntelliGitArguments
{
    public bool Staged { get; set; }
    public int NumberOfEstimatedCommits { get; set; }
}
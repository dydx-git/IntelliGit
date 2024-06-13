using Domain.Interfaces;
using Domain.Types;
using LibGit2Sharp;

namespace SourceControlProvider;

public class GitRepoInfo(Repository repository) : IGitRepoInfo
{

    public IEnumerable<Branch> GetBranches()
    {
        return repository.Branches.ToList();
    }

    public Branch GetBranch(BranchName branchName)
    {
        return repository.Branches[branchName.Value];
    }

    public IEnumerable<string> GetUncommittedChanges()
    {
        return repository.RetrieveStatus()
            .Where(status => status.State != FileStatus.Ignored)
            .Select(status => status.FilePath)
            .ToList();
    }

    public IEnumerable<string> GetCommitLog(int numberOfCommits)
    {
        return repository.Commits.Take(numberOfCommits)
            .Select(commit => commit.Message)
            .ToList();
    }

    public string GetFileDiff(FilePath filePath)
    {
        var patch = repository.Diff.Compare<Patch>(null, DiffTargets.WorkingDirectory, new[] { filePath.Value });
        return patch.Content;
    }

    public bool IsRepositoryClean()
    {
        return !repository.RetrieveStatus().IsDirty;
    }
}

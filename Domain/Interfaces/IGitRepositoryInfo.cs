using Domain.Types;
using LibGit2Sharp;

namespace Domain.Interfaces;

public interface IGitRepositoryInfo
{
    protected IRepository Repository { get; }

    IEnumerable<Branch> GetBranches();
    Branch GetBranch(BranchName branchName);
    IEnumerable<string> GetUncommittedChanges();
    IEnumerable<string> GetCommitLog(int numberOfCommits);
    string GetFileDiff(FilePath filePath);
    bool IsRepositoryClean();
}
using Domain.Types;
using LibGit2Sharp;

namespace Domain.Interfaces;

public interface IGitCommandExecutor
{
    MergeResult Pull(BranchName branchName);
    void Push(RemoteName remoteName, BranchName branchName);
    Commit Commit(CommitMessage message, AuthorName authorName, AuthorEmail authorEmail);
    Branch Checkout(BranchName branchName);
    Branch CreateBranch(BranchName branchName);
    MergeResult Merge(BranchName branchToMerge);
}

public interface IGitRepoInfo
{
    IEnumerable<Branch> GetBranches();
    Branch GetBranch(BranchName branchName);
    IEnumerable<string> GetUncommittedChanges();
    IEnumerable<string> GetCommitLog(int numberOfCommits);
    string GetFileDiff(FilePath filePath);
    bool IsRepositoryClean();
}
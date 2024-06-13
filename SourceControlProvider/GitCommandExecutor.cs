using Domain;
using Domain.Interfaces;
using Domain.Types;
using LibGit2Sharp;

namespace SourceControlProvider;

public class GitCommandExecutor(Repository repository) : IGitCommandExecutor
{
     public MergeResult Pull(BranchName? branchName = null)
     {
          if (branchName is not null)
          {
               Checkout(branchName);
          }
          var signature = repository.Config.BuildSignature(DateTimeOffset.Now);
          return Commands.Pull(repository, signature, new PullOptions());
     }
     
     public void Push(RemoteName remoteName, BranchName? branchName = null)
     {
          if (branchName is not null)
          {
               var branch = repository.Branches[branchName.Value];
               Commands.Checkout(repository, branch);
          }
          var remote = repository.Network.Remotes[remoteName.Value];
          if (branchName is null)
          {
               var branch = repository.Head;
               branchName = new BranchName(branch.CanonicalName);
          }
          repository.Network.Push(remote, branchName.Value, new PushOptions());
     }
     
     public Commit Commit(CommitMessage message, AuthorName? authorName = null, AuthorEmail? authorEmail = null)
     {
          var signature = repository.Config.BuildSignature(DateTimeOffset.Now);
          if (authorName is not null && authorEmail is not null)
          {
               signature = new Signature(authorName.Value, authorEmail.Value, DateTimeOffset.Now);
          }
          return repository.Commit(message.Value, signature, signature);
     }
     
     public Branch Checkout(BranchName branchName)
     {
          var branch = repository.Branches[branchName.Value];
          return Commands.Checkout(repository, branch);
     }
     
     public Branch CreateBranch(BranchName branchName)
     {
          var branch = repository.CreateBranch(branchName.Value);
          return Commands.Checkout(repository, branch);
     }
     
     public MergeResult Merge(BranchName branchToMerge)
     {
          var branch = repository.Branches[branchToMerge.Value];
          return repository.Merge(branch, repository.Config.BuildSignature(DateTimeOffset.Now));
     }
}
using Domain.SeedWork;

namespace Domain.Types;

public record BranchName(string Value) : ValueObject<string>(Value);
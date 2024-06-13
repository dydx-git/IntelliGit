using Domain.SeedWork;

namespace Domain.Types;

public record CommitMessage(string Value) : ValueObject<string>(Value);
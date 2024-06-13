using Domain.SeedWork;

namespace Domain.Types;

public record FilePath(string Value) : ValueObject<string>(Value);
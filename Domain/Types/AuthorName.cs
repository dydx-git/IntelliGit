using Domain.SeedWork;

namespace Domain.Types;

public record AuthorName(string Value) : ValueObject<string>(Value);
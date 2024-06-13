using Domain.SeedWork;

namespace Domain.Types;

public record AuthorEmail(string Value) : ValueObject<string>(Value);
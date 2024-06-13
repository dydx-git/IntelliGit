using Domain.SeedWork;

namespace Domain.Types;

public record RemoteName(string Value) : ValueObject<string>(Value);
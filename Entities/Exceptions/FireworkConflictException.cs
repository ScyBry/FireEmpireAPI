using Entities.Models;

namespace Entities.Exceptions
{
    public sealed class FireworkConflictException : ConflictException
    {
        public FireworkConflictException(Firework firework) : base($"Фейрверк {firework} уже существует") { }
    }
}

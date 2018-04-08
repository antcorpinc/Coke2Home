using System;

namespace MG.Jarvis.Core.Contracts
{
    public interface IIdentifiableModel<T>
    {
        T Id { get; set; }
    }
}

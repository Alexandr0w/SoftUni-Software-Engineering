﻿namespace _02.DI.Core.Interfaces
{
    public interface IModule
    {
        void Configure();

        object? GetService(Type serviceType);
        T? GetService<T>(); 
    }
}

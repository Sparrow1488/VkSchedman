﻿namespace VideoSchedman.Abstractions
{
    internal interface IExecutableProcess
    {
        Task StartAsync(string command);
        Task StartDebugAsync(string command);
        IExecutableProcess FilePathFromConfig();
    }
}

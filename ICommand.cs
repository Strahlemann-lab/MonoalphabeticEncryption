﻿public interface ICommand
{
    void Execute(CommandContext context, string[] parameters);
}
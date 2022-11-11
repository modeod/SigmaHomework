﻿namespace SigmaHomework_6_ConsoleClient.Services.Interfaces
{
    public interface IFileHandler
    {
        string PathToRead { get; set; }
        string PathToWrite { get; set; }

        string[] Read();

        string[] Read(string path);

        void WriteOverride(string text);

        void WriteOverride(string path, string text);

        void Write(string path, string text);

        void Write(string text);
    }
}
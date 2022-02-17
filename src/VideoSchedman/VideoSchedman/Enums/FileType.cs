﻿namespace VideoSchedman.Enums
{
    public class FileType
    {
        private FileType(string name) 
        { 
            Name = name;
        }

        public readonly string Name;

        public static readonly FileType Video = new FileType("Video");
        public static readonly FileType Audio = new FileType("Audio");
        public static readonly FileType Undefined = new FileType("Undefined");
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Commands
{
    public class ReplaceTextCommand : BaseCommand
    {
        public ReplaceTextCommand(string path) : base(path)
        {
        }

        public ReplaceTextCommand(string path, string textToReplace): base(path)
        {
            TextToReplace = textToReplace;
        }

        public string TextToReplace { get; set; }

        public override bool DoWork()
        {
            if (!base.DoWork())
            {
                return false;
            }

            var text = File.ReadAllText(Location);

            if (TextToReplace.Length > 0 && text.Contains(TextToReplace))
            {
                //Store original file
                File.Copy(Location, Location + ".origin", true);
                text = text.Replace(TextToReplace, "", true, null);
                File.WriteAllText(Location, text);
                Utils.Output($"Text without the word \"{TextToReplace}\"", ConsoleColor.Green);
                Utils.Output(text);
            }
            else
            {
                Utils.OutputError($"Text does not contain the word \"{TextToReplace}\"");
                Utils.Output(text);
            }
            return true;
        }
    }
}

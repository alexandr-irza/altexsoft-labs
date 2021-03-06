﻿using ConsoleApp.Commands;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class CountWordsCommand : BaseCommand
    {

        public CountWordsCommand(string path) : base(path)
        {
        }

        public override bool DoWork()
        {
            if(!base.DoWork())
            {
                return false;
            }
            var text = File.ReadAllText(Location);

            var pattern = @"\w+[\w'-]*";
            var words = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            Utils.Output("Words count:", ConsoleColor.Green);
            Utils.Output(words.Count.ToString());

            Utils.Output("Every 10th word separated by comma:", ConsoleColor.Green);
            Utils.Output(string.Join(',', words.Where((x, i) => i % 10 == 0)));
            return true;
        }
    }
}

using System;
using System.IO;
using System.Text.Json;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        int currentLevel = 0;
        static void Main(string[] args)
        {
            DisplayTerrain(0);
        }

        static void DisplayTerrain(int levelIndex) {
            string json = File.ReadAllText($"Levels/level{levelIndex}.json");
            Level level = JsonSerializer.Deserialize<Level>(json);
            Console.WriteLine(json);
            //Console.WriteLine(level.Stringify(0));
        }

        class Level {
            public List<Block> blocks = new List<Block>();

            public List<Layer> layers = new List<Layer>();

            public class Layer {
                public List<string> terrain = new List<string>();
            }

            public class Block {
                public string block;
                public string id;
            }

            public string Stringify(int layer)
            {
                return string.Join("\n", layers[layer]);
            }
        }
    }
}
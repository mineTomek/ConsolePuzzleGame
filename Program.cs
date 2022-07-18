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
            Level? level = JsonSerializer.Deserialize<Level>(json, new JsonSerializerOptions() {});
            Console.WriteLine(level.layers.Length);
            //Console.WriteLine(level.Stringify(0));
        }

        class Level {
            public Block[] blocks;

            public Layer[] layers;

            public class Layer {
                public string[] terrain;
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
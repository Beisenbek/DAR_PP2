using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Layer {

        public List<FileSystemInfo> items;
        public int index;

        public FileSystemInfo GetSelectedItem()
        {
            return items[index];
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < items.Count; ++i)
            {
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i].Name);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows\PLA\Rules");
            Console.ForegroundColor = ConsoleColor.White;

            Stack<Layer> history = new Stack<Layer>();
            Layer layer =  new Layer();
            layer.index = 0;
            layer.items = directoryInfo.GetFileSystemInfos().ToList();
            history.Push(layer);

            while (true)
            {
                history.Peek().Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().index--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().index++;
                        break;
                    case ConsoleKey.Enter:
                        var item = history.Peek().GetSelectedItem();
                        if (item.GetType() == typeof(DirectoryInfo)) {
                            Layer layer2 = new Layer();
                            layer2.index = 0;
                            layer2.items = (item as DirectoryInfo).GetFileSystemInfos().ToList();
                            history.Push(layer2);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        history.Pop();
                        break;
                }
            }
        }
    }
}

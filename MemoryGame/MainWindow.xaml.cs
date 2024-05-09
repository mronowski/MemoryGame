using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> translations = new List<string>
            {
                "kot", "cat",
                "oko","eye",
                "nos","nose",
                "pies","dog",
                "ptak","bird",
                "noga","leg",
                "ryba","fish",
                "ręka","arm"

            };
            List<Word> words = new List<Word>
            {
                new Word("kot", 1),
                new Word("cat", 1),
                new Word("oko", 2),
                new Word("eye", 2),
                new Word("nos", 3),
                new Word("nose", 3),
                new Word("pies", 4),
                new Word("dog", 4),
                new Word("ptak", 5),
                new Word("bird", 5),
                new Word("noga", 6),
                new Word("leg", 6),
                new Word("ryba", 7),
                new Word("fish", 7),
                new Word("ręka", 8),
                new Word("arm", 8)
            };
           
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(words.Count);
                string nextTrans = words[index].TheWord;
                int nextID = words[index].Id;
                textBlock.Text = nextTrans;
                textBlock.LineHeight = nextID;
                words.RemoveAt(index);
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Background = Brushes.White;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.LineHeight == lastTextBlockClicked.LineHeight && textBlock != lastTextBlockClicked)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Background = Brushes.Black;
                textBlock.Background = Brushes.Black;
                findingMatch = false;
            }
        }
    }
}

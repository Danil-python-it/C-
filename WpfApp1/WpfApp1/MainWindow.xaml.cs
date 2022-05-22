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

namespace шещп
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Animal>Animals = new Dictionary<string, Animal>(0);
        string MouseStatus = "CreateNewAnimal";
        int index = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            foreach(var i in Animals)
            {
                if (i.Value.MoveLeft != i.Value.left || i.Value.MoveTop != i.Value.top)
                {
                    if (i.Value.left < i.Value.MoveLeft) { i.Value.Translaiet(i.Value.speed,0);}
                    if (i.Value.left > i.Value.MoveLeft) { i.Value.Translaiet(i.Value.speed*-1, 0); }
                    if (i.Value.top < i.Value.MoveTop) { i.Value.Translaiet(0,i.Value.speed); }
                    if (i.Value.top > i.Value.MoveTop) { i.Value.Translaiet(0,-1*i.Value.speed); }
                    
                }
                if (i.Value.MoveLeft == i.Value.left && i.Value.MoveTop == i.Value.top)
                {
                    Random rand = new Random();
                    i.Value.MoveLeft = i.Value.left + rand.Next(-50, 50);
                    i.Value.MoveTop = i.Value.top + rand.Next(-50, 50);
                }
            }
        }

        private void MainWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MouseStatus == "CreateNewAnimal")
            {
                Random rand = new Random();
                SolidColorBrush color = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rand.Next(1, 255)), Convert.ToByte(rand.Next(1, 255)), Convert.ToByte(rand.Next(1, 255))));
                Animal temp = new Animal(4,2, Convert.ToInt32(e.GetPosition(can).X), Convert.ToInt32(e.GetPosition(can).Y));
                temp.SetColor(color);
                temp.Load();
                can.Children.Add(temp.Get());
                Animals.Add(index.ToString(),temp);
                index++;
            }

        }

        private void NewAnim_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "CreateNewAnimal";
        }

        private void NewTree_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "CreateNewTrees";
        }

        private void None_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "none";
        }
    }
}
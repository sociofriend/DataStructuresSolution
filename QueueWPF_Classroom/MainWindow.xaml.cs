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

namespace QueueWPF_Classroom;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Queue<int> _queue = new Queue<int>();
    Random _rnd = new Random();
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Enqueue(object sender, RoutedEventArgs e)
    {
        _queue.Enqueue(_rnd.Next(0, 200));
        UpdateGrid();
    }

    private void Button_Dequeue(object sender, RoutedEventArgs e)
    {
        if(_queue.Count > 0)
        {
            lstBox.Items.Add(_queue.Dequeue());
            UpdateGrid();
        }
    }


    private void UpdateGrid()
    {
        lbl1.Content = string.Empty;
        lbl2.Content = string.Empty;
        lbl3.Content = string.Empty;
        lbl4.Content = string.Empty;
        lbl5.Content = string.Empty;

        int index = 0;

        foreach(int item in _queue)
        {
            switch(index)
            {
                case 0:
                    lbl1.Content = item.ToString();
                    break;
                case 1:
                    lbl2.Content = item.ToString();
                    break;
                case 2:
                    lbl3.Content = item.ToString();
                    break;
                case 3:
                    lbl4.Content = item.ToString();
                    break;
                case 4:
                    lbl5.Content = item.ToString();
                    break;
                default:
                    break;
            }
            
            index++;
            if (index > 5)
                break;
        }
    }
}

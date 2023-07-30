using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StackLibrary;

namespace ColorConverterWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //Button CurrentButton { get; set; }
    Stack<Button> CurrentButtonStack { get; set; } = new Stack<Button>();

    CustomStack<Color> ColorStack { get; set; } = new CustomStack<Color>();

    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event handler for which is called when the corresponding button is clicked.
    /// </summary>
    /// <param name="sender">"Here the "Undo" button.</param>
    /// <param name="e">Standard parameter for event handlers in WPF.</param>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //call method responsible for changin the button's collor getting
        //the button's variable as argument.
        ChangeButtonColor(btn1);
    }

    /// <summary>
    /// Event handler for which is called when the corresponding button is clicked.
    /// </summary>
    /// <param name="sender">"Here the "Undo" button.</param>
    /// <param name="e">Standard parameter for event handlers in WPF.</param>
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        //call method responsible for changin the button's collor getting
        //the button's variable as argument.
        ChangeButtonColor(btn2);
    }

    /// <summary>
    /// Event handler for which is called when the corresponding button is clicked.
    /// </summary>
    /// <param name="sender">"Here the "Undo" button.</param>
    /// <param name="e">Standard parameter for event handlers in WPF.</param>
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        //call method responsible for changin the button's collor getting
        //the button's variable as argument.
        ChangeButtonColor(btn3);
    }

    /// <summary>
    /// Method is responsible for choosing specific button's color which is passed as argument.
    /// </summary>
    /// <param name="btn">Local variable representing the relevant button to change.</param>
    public void ChangeButtonColor(Button btn)
    {
        //create random type object
        Random random = new Random();

        //create an array for byte type values to store 3 colors: R, G, B
        byte[] colorBytes = new byte[3]; //red green blue

        //generate random bytes to store in colorBytes array thus generating random colors using the Random class
        random.NextBytes(colorBytes);

        //create a new Color instance from the specified red, green, and blue (RGB) components
        Color newColor = Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);

        //store previous color for undo
        ColorStack.Push(((SolidColorBrush)btn.Background).Color);

        //change button background
        btn.Background = new SolidColorBrush(newColor);

        //add current list code to listbox.
        lstBox.Items.Add(newColor.ToString());
        //CurrentButton = btn;
        CurrentButtonStack.Push(btn);
    }

    /// <summary>
    /// Undo button reverts colors of the color-boxes simultaniously deleting hex-codes 
    /// from the ListBox preview space. The logic uses colors' and buttons' stacks, storing previous
    /// colors and removing one-by-one.
    /// </summary>
    /// <param name="sender">"Here the "Undo" button.</param>
    /// <param name="e">Standard parameter for event handlers in WPF.</param>
    private void undoButton_Click(object sender, RoutedEventArgs e)
    {
        if(ColorStack.Count > 0)
        {
            //store previous color in local variable and pop it from the colors' stack
            Color previousColor = ColorStack.Pop();
            
            //store current button in local variable and pop it from the buttons' stack
            Button currentButton = CurrentButtonStack.Pop();
            
            //now change current button's color to previous color stored in local variable
            currentButton.Background = new SolidColorBrush(previousColor);
            
            //decrease the count of items in ListBox by one.
            lstBox.Items.RemoveAt(lstBox.Items.Count - 1);
        }
    }
}

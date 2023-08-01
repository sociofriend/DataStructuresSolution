﻿using CustomQueueLibrary;
using LinkedListLibrary;
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

namespace QueueWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //single-dimension array of Lable type items to store labels' objects.
    public Label[] lblArray { get; set; }

    //custom queueLinkedList to store randomly generated numbers.
    public CustomQueue<int> numbersQueue { get; set; }

    //conditional variable to define whether print function is called after Enqueu or Dequeue events.
    // 0 - for Enqueue, 1- for Dequeue.
    int status;

    public MainWindow()
    {
        InitializeComponent();

        //initialize local properties.
        numbersQueue = new CustomQueue<int>();
        lblArray = new Label[] { lbl1, lbl2, lbl3, lbl4, lbl5 };
    }

    /// <summary>
    /// Event handler for Enqueue function.
    /// </summary>
    /// <param name="sender">Enqueue button.</param>
    /// <param name="e">Non-used event's arguments.</param>
    private void Button_Click(object sender, RoutedEventArgs e)

    {
        //create Random type object to get random numbers
        Random random = new Random();
        int number = random.Next(0, 100);

        //add the new number to numbers' Queue Linked List
        numbersQueue.Enqueue(number);

        //add the number to listbox
        lstBox.Items.Add(number);

        //set status to 0, meaning that the print function is called after Enqueue event was handled.
        status = 0;

        //now print the hard work was done!!
        PreviewQueueNumbers(status);


    }

    /// <summary>
    /// Event handler for Dequeue function.
    /// </summary>
    /// <param name="sender">Dequeue button.</param>
    /// <param name="e">Non-used event's arguments.</param>
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        //delete first item/input of the queue (FIFO)
        numbersQueue.Dequeue();

        //remove first item of the listbox
        lstBox.Items.RemoveAt(0);

        //set status to 0, meaning that the print function is called after Dequeue event was handled.
        status = 1;

        //now print the hard work was done!!
        PreviewQueueNumbers(status);
    }

    /// <summary>
    /// Prints numbers on the label and listbox.
    /// </summary>
    /// <param name="_status">Local variable identifying if the method is invoked after 
    /// Enqueue or Dequeue event was handled.</param>
    private void PreviewQueueNumbers(int _status)
    {
        {
            //check if the method is invoked after Enqueue or Dequeue event was handled.
            if (status == 1)
            {
                //if the method was invoked after the Dequeue event was handled
                //set contents of all labels to empty space. 
                for (int i = 0; i < lblArray.Length; i++)
                {
                    lblArray[i].Content = "";
                }
            }

            //local variable to identify the index of the label's array.
            int index = 0;

            //create local variable for first item of the queue
            CustomNode<int> current = numbersQueue.Head;
            
            //where the value exists assign to respective label. Do it till the last label of th array.
            while (current != null && index != 5)
            {
                lblArray[index].Content = current.Value;
                index++;
                current = current.NextNode;
            }
        }
    }

    /// <summary>
    /// Clears teh Queue.
    /// </summary>
    /// <param name="sender">Dequeue button.</param>
    /// <param name="e">Non-used event's arguments.</param>
    private void clr_Click(object sender, RoutedEventArgs e)
    {
        numbersQueue.Clear();
        lstBox.Items.Clear();
        for (int i = 0; i < lblArray.Length; i++)
        {
            lblArray[i].Content = "";
        }

    }
}

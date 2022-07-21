using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoadXMLToMUTdBase.Properties;
using System.ComponentModel;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Windows.Media.Animation;


namespace LoadXMLToMUTdBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string dataFromFile, buffer;
        //public static object buffer;
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_OnClosed;
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Выясняем, действительно ли пользователь хочет закрыть окно.
            string msg = "Do you want to close without saving?\t";
            MessageBoxResult result = MessageBox.Show(msg, "WARNING!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                //Если пользователь не желает открыть окно, то отменить закрытие
                e.Cancel = true;
            }       
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            //MessageBox.Show("Be well !!");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        public void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToolsClick(object sender, RoutedEventArgs e)
        {

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileLoad_Click(object sender, RoutedEventArgs e)
        {
            ConvEXDFtoXML ConvFls = new ConvEXDFtoXML();
            ConvFls.ConvertFiles();
            string ConvData = Data.SendConvData;
            textBoxData.Clear();
            textBoxData.Text = (string)(ConvData);
            //dataGridXML.ItemsSource = (string)(ConvData);
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {

            var saveDlg = new SaveFileDialog { Filter = "Text Files |*.xml" };
            if (true == saveDlg.ShowDialog())
            {
                if (textBoxData.Text == "") 
                {
                    MessageBox.Show("Select EXDF-file !!");
                    return;
                }
                try
                {
                    //Загрузить содержимое выбранного файла
                    File.WriteAllText(saveDlg.FileName, textBoxData.Text);
                    MessageBox.Show("\tFile created !!\t");
                }
                catch
                {
                    MessageBox.Show("\tError create file !!\t");
                }
            }
            //textBoxData.Clear();
        }

        private void FileConvert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void OpenCmdExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void textBoxData_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
        {

        }

        private void dataGridXML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClick_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridXML_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLinq_Click(object sender, RoutedEventArgs e)
        {
            string DataXML = "";
            textBoxData.Clear();
            LINQtoXML GetData = new LINQtoXML();
            GetData.SelectDataXML();
            DataXML = Data.SendXMLData;
            //textBoxData.Clear();
            textBoxData.Text = (string)(DataXML);
            //dataGridXML.ItemsSource = (string)(DataXML);
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxData.Clear();
        }

        public void textBoxFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string stringFrom = textBoxFrom.Text;
        }

        private void textBoxwhere_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Data.stringWhere = textBoxWhere.Text;
        }

        private void textBoxOrderby_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Data.stringOrderby = textBoxFrom.Text;
        }

        private void textBoxSelect_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Data.stringSelect = textBoxFrom.Text;
        }

        private void textBoxIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Data.stringIn = textBoxIn.Text;
        }

        private void textBoxBool_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Data.stringBool = textBoxBool.Text;
        }

        private void dataGridXML_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

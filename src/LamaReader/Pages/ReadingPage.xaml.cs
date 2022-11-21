using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using IronOcr;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using LamaReader.Services;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Windows.Automation;
using wpfpslib;
using System.Threading.Tasks;

namespace LamaReader.Pages
{
    /// <summary>
    /// Interaction logic for ReadingPage.xaml
    /// </summary>
    public partial class ReadingPage: Page
    {
        public ReadingPage()
        {
            InitializeComponent();
            pdfViewer.ViewMode = Patagames.Pdf.Net.Controls.Wpf.ViewModes.Horizontal;
        }
        public void OpenDocument(string path)
        {
            pdfViewer.LoadDocument(new DocumentConverter().to_pdf(path));
            pdfViewer.UpdateDefaultStyle();
        }
        private void BrowseButton(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Document files(*.pdf;*.docx;*.doc;*.md;*.html;*.txt);|*.pdf;*.docx;*.doc;*.md;*.html;*.txt";

            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
                OpenDocument(dialog.FileName);
        }
        public void DarkTheme(object sender, RoutedEventArgs e)
        {
            BookFilter.Opacity = 0;
            pdfViewer.Effect = new InvertEffect();
        }
        public void SepiaTheme(object sender, RoutedEventArgs e)
        {
            pdfViewer.Effect = null;
            BookFilter.Opacity = 0.15;
            BookFilter.Color = Colors.Yellow;
        }
        public void LightTheme(object sender, RoutedEventArgs e)
        {
            pdfViewer.Effect = null;
            BookFilter.Opacity = 0;
        }
        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainGrid.Focus();
        }
        void NextPage(object sender, RoutedEventArgs e)
        {
            pdfViewer.PageRight();     
        } 
        void PreviousPage(object sender, RoutedEventArgs e)
        {
            pdfViewer.PageLeft();     
        }
 
        void CanvasMouseWheel(object sender, RoutedEventArgs e)
        {
            pdfViewer.RaiseEvent(e);
        }
        void CanvasKeyPressed(object sender, KeyEventArgs e)
        {
            if (new[] { Key.Left, Key.H, Key.A }.Contains(e.Key))
                pdfViewer.PageLeft();
            else if (new[] { Key.Right, Key.L, Key.D }.Contains(e.Key))
                pdfViewer.PageRight();
            else if (new[] { Key.Down, Key.S, Key.K }.Contains(e.Key))
                pdfViewer.ScrollOwner.ScrollToVerticalOffset(pdfViewer.VerticalOffset + 8);
            else if (new[] { Key.Up, Key.W, Key.J }.Contains(e.Key))
                pdfViewer.ScrollOwner.ScrollToVerticalOffset(pdfViewer.VerticalOffset - 8);

        }

        private Point start_point;
        private Rectangle rect;
        
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start_point = e.GetPosition(canvas);

            rect = new Rectangle
            {
                Stroke = Brushes.LightBlue,
                StrokeThickness = 2
            };
            Canvas.SetLeft(rect, start_point.X);
            Canvas.SetTop(rect, start_point.Y);
            canvas.Children.Add(rect);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || rect == null)
                return;

            var pos = e.GetPosition(canvas);

            var x = Math.Min(pos.X, start_point.X);
            var y = Math.Min(pos.Y, start_point.Y);

            var w = Math.Max(pos.X, start_point.X) - x;
            var h = Math.Max(pos.Y, start_point.Y) - y;

            rect.Width = w;
            rect.Height = h;

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            canvas.Children.Clear();
            start_point = canvas.PointToScreen(start_point);
            Point end_point = canvas.PointToScreen(e.GetPosition(canvas));
            
            Task.Run(() => CopyText(start_point, end_point)).
                ContinueWith(async_result => Application.Current.Dispatcher.Invoke(() => Clipboard.SetDataObject(async_result.Result)));
                        
        }
        private string CopyText(Point start_point, Point end_point)
        {
            if (this.start_point.X == end_point.X || this.start_point.Y == end_point.Y)
                return "";
            using (var bmp = new System.Drawing.Bitmap((int)Math.Abs(start_point.X - end_point.X),
                (int)Math.Abs(start_point.Y - end_point.Y)))
            {
                using (var g = System.Drawing.Graphics.FromImage(bmp))
                {
                    String filename = "ScreenCapture.bmp";
                   
                    g.CopyFromScreen((int)(Math.Min(start_point.X, end_point.X) + SystemParameters.VirtualScreenLeft), 
                                     (int)(Math.Min(start_point.Y, end_point.Y) + SystemParameters.VirtualScreenTop),
                                     0, 0, bmp.Size);

                    bmp.Save(filename);                
                }

            }
            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.UkrainianFast;
            Ocr.AddSecondaryLanguage(OcrLanguage.EnglishFast);
            using (var Input = new OcrInput())
            {
                Input.AddImage("ScreenCapture.bmp");
                var Result = Ocr.Read(Input);
                return Result.Text;
            }

        }

    }
}

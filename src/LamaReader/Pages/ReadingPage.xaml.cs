using LamaReader.Data;
using LamaReader.MainLogic;
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

namespace LamaReader.Pages
{
    /// <summary>
    /// Interaction logic for ReadingPage.xaml
    /// </summary>
    public partial class ReadingPage : Window
    {
        private readonly IAuth auth;
        private readonly LlamaReaderDbContext dbContext;

        public ReadingPage(IAuth auth, LlamaReaderDbContext dbContext)
        {
            InitializeComponent();
            this.auth = auth;
            this.dbContext = dbContext;
        }
    }
}

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
using System.Data.SqlClient;
using System.Data;
using System;
using TVDCalculator;

namespace TVDCaculator
{
    public partial class MainWindow : Window
    {
        private double _md;
        private double _alpha;

        public double MD
        {
            get { return _md; }
            set { _md = value; }
        }

        public double Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();

        private void tvdcalculate_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(md_textbox.Text) || string.IsNullOrWhiteSpace(alpha_textbox.Text))
            {
                MessageBox.Show("Please fill all of data");
                return;
            }
            if (double.TryParse(md_textbox.Text, out _md) && double.TryParse(alpha_textbox.Text, out _alpha))
            {
                double alphaInRadians = _alpha * (Math.PI / 180);

                double tvdResult = _md * Math.Cos(alphaInRadians);

                tvd_textbox.Text = tvdResult.ToString();

                string query = $"INSERT INTO TVDTable (MD, Alpha, TVD) VALUES ({_md}, {_alpha}, {tvdResult})";
                modify.Command(query);

                TVD_DataGridView.ItemsSource = modify.Table($"SELECT * FROM TVDTable WHERE MD <= {_md}").DefaultView;
            }
        }


        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            md_textbox.Text = "";
            alpha_textbox.Text = "";
            tvd_textbox.Text = "";

            try
            {
                TVD_DataGridView.ItemsSource = modify.Table("Select * from TVDTable ORDER BY MD ASC").DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = modify.Table("Select * from TVDTable");
                TVD_DataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TbdMoney
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string SqliteFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "TbdMoneyDatabase.sqlite");

        public MainPage()
        {
            this.InitializeComponent();

            CreateSqliteDatabase();

            Debug.WriteLine(SqliteFilePath);
        }

        private void CreateSqliteDatabase()
        {
            using (var conn = new SqliteConnection($"Data Source={SqliteFilePath}"))
            {
                conn.Open();

                var CreateTransactionTable = conn.CreateCommand();
                CreateTransactionTable.CommandText = @"CREATE TABLE IF NOT EXISTS TransactionTable (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Timestamp INTEGER NOT NULL,
                    Account STRING NOT NULL,
                    Description STRING NOT NULL,
                    Amount FLOAT NOT NULL
                )";
                CreateTransactionTable.ExecuteNonQuery();
            }
        }

        private void OpenNatwestCSV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenHalifaxCSV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Xaml.Controls;

namespace A5__Automation_Tool
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // delet the temp folder
            string temp_Path = Path.GetTempPath();
            long size_before = 0;
            long size_after = 0;

            try
            {
                foreach (string file in Directory.GetFiles(temp_Path, "*", SearchOption.AllDirectories))
                {

                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        size_before += fi.Length;

                        fi.Delete();

                        size_after += fi.Length;
                    }
                    catch { }
                }

                foreach (string folder in Directory.GetDirectories(temp_Path))
                {
                    try
                    {
                        Directory.Delete(folder, true);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Failed to access the Temp folder. " + ex.Message);
            }

            // find the free space in C drive
            DriveInfo cDrive = new DriveInfo("C");
            long freeSpaceInC = cDrive.AvailableFreeSpace;

            long deleted_size = size_before - size_after;
            //windoes notfication 
            ToastContentBuilder notyf = new ToastContentBuilder();
            notyf.AddText("The Temp folder has been cleaned"); // title

            notyf.AddText($"{SizeFormat(deleted_size)} deleted\n"+
                          $"Free space in C: {SizeFormat(freeSpaceInC)}"); //description

            notyf.AddText(DateTime.Now.ToShortTimeString()); //description
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KAITECH Logo.png");

            notyf.AddInlineImage(new Uri(Path.GetFullPath(imagePath)));
            notyf.Show();

            Environment.Exit(0);

        }


        #region helper functions
            // findg the right size formating
        static string SizeFormat(long bytes)
        {
            string[] unit = { "B", "KB", "MB", "GB" };

            double size = bytes;

            int index = 0;

            while (size >= 1024 && index < unit.Length - 1)
            {
                index++;
                size /= 1024;
            }
            return $"{size:0.##} {unit[index]}";

        }

        
        #endregion
    }
}


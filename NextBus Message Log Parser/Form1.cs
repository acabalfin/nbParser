using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;        // Used for file read/write

namespace NextBus_Message_Log_Parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            // This method will obtain the path of the file to parse.

            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = open.ShowDialog();
            string path = "";
            
            if (dr == DialogResult.OK)
            {
                path = open.FileName;
                if (!path.EndsWith(".txt"))
                {
                    MessageBox.Show("Not a valid file format");
                    return;
                }
                filePath_in.Text = path;
                Parse_button.Enabled = true;
            }
        }

        private void Parse_button_Click(object sender, EventArgs e)
        {
            // This method will initiate the data parsing and creation of .csv file

            FileStream fs_in = new FileStream(filePath_in.Text, FileMode.Open);
            StreamReader sr = new StreamReader(fs_in);

            string filename_out = filePath_in.Text;
            string line;
            string messageType, report;
            string[] message, AVLReportContents;

            string deviceID, dtm, lat, longitude, direction, speed, satCount, satLock;

            DateTime dtm_convert = new DateTime();
            long res;

            string dir, dir1, dir2;

            int temp = 1;

            if (File.Exists(filename_out + "_parsed.csv"))
            {
                while (File.Exists(filename_out + "_parsed(" +  temp.ToString() + ").csv"))
                {
                    temp++;
                }
                
                filename_out = filePath_in.Text + "_parsed(" + temp.ToString() + ").csv";                
            }

            else
                filename_out = filePath_in.Text + "_parsed.csv";
            
            FileStream fs_out = new FileStream(filename_out, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs_out);

            sw.WriteLine("Device ID,Date/Time,Lat (DMS),Long (DMS),Direction,Speed,Num Sat,Lock?");

            while ((line = sr.ReadLine()) != null)
            {
                message = line.Split(':');
                messageType = message[0];
                report = message[1];

                switch (messageType)
                {
                    case "AVLReport":
                        AVLReportContents = report.Split('|');
                        
                        deviceID = AVLReportContents[0];
                        dtm = AVLReportContents[1];
                        lat = AVLReportContents[2];
                        longitude = AVLReportContents[3];
                        direction = AVLReportContents[4];
                        speed = AVLReportContents[5];
                        satCount = AVLReportContents[6];
                        satLock = AVLReportContents[7];

                        if (long.TryParse(dtm, out res))
                            dtm_convert = FromUnixTime(res);

                        dir = directionConversion(direction);
                        
                        // Conversion from hex string to decimal to ASCII
                        dir1 = dir.Substring(0, 2);     // First 2 bytes represent N or S direction
                        dir2 = dir.Substring(2, 2);     // Second 2 bytes represent E or W direction


                        // Conversion from hex to decimal
                        int num = Int32.Parse(dir1, System.Globalization.NumberStyles.HexNumber);
                        int num2 = Int32.Parse(dir2, System.Globalization.NumberStyles.HexNumber);

                        // Conversion from decimal to ASCII
                        char u1 = (char) num, u2 = (char) num2;

                        // Concatenate string (i.e. NW, SE, etc.)
                        direction = u1.ToString() + u2.ToString();

                        sw.WriteLine(deviceID + "," + dtm_convert.ToString() + "," + lat + "," + longitude + ","
                            + direction + "," + speed + "," + satCount + "," + satLock);

                        break;

                    default:
                        break;
                }
            }

            sr.Close();
            sw.Close();

            filePath_out.Text = filename_out;       // Provide the path of resulting parsed file
        }

        private DateTime FromUnixTime (long epoch)
        {
            // Converts Unix Time (epoch) to normal date/time
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            return converted.AddSeconds(epoch);
        }

        private string directionConversion(string dir)
        {
            // This method converts the direction (given in base 10) to a hex number
            int num = Convert.ToUInt16(dir);
            string ans = Convert.ToString(num, 16);

            return ans;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
                filePath_in.Text = path;
            }
        }

        private void Parse_button_Click(object sender, EventArgs e)
        {
            FileStream fs_in = new FileStream(filePath_in.Text, FileMode.Open);
            StreamReader sr = new StreamReader(fs_in);

            string filename_out = filePath_in.Text + "_parsed.txt";
            string line;
            string messageType, report;
            string[] message, AVLReportContents;

            string deviceID, dtm, lat, longitude, speed, satCount, satLock;

            DateTime dtm_convert = new DateTime();
            long res;

            FileStream fs_out = new FileStream(filename_out, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs_out);

            sw.WriteLine("Device ID\t\tDate/Time\t\tLat (Dec)\t\tLong (Dec)\t\tSpeed\t\tNum Sat\tLock?\r\n\r\n");

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
                        speed = AVLReportContents[4];
                        satCount = AVLReportContents[5];
                        satLock = AVLReportContents[6];

                        if (long.TryParse(dtm, out res))
                            dtm_convert = FromUnixTime(res);

                        sw.WriteLine(deviceID + "\t" + dtm_convert.ToString() + "\t" + lat + "\t" + longitude + "\t"
                            + speed + "\t" + satCount + "\t" + satLock + "\r\n");

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
            // Converts Unix Time to normal date/time
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            return converted.AddSeconds(epoch);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

using LDD_22.Code;

namespace LDD_22
{
    public partial class priimimasis : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Delete all past files from the server

            // Multiple
            string savePathMultipledel = Server.MapPath("/App_Data/Data/InFiles/");
            DirectoryInfo di = new DirectoryInfo(savePathMultipledel);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            // Single
            string savePathSingle = Server.MapPath("/App_Data/Data/ParlamentMembers.txt");
            FileInfo fi = new FileInfo(savePathSingle);
            fi.Delete();


            // Reading and uploading files to App_Data folder
            try
            {
                if (FileUpload1.HasFile) // Multiple files
                {
                    // file paths
                    string savePathMultiple = Server.MapPath("/App_Data/Data/InFiles/");
                    string fileNameMultiple = Server.HtmlEncode(FileUpload1.FileName);
                    string extensionMultiple = Path.GetExtension(fileNameMultiple);

                    foreach (var selectedFile in FileUpload1.PostedFiles)
                    {
                        string fileNamesMultiple = Path.GetFileName(selectedFile.FileName);
                        selectedFile.SaveAs(savePathMultiple + fileNamesMultiple);
                    }


                    if (FileUpload2.HasFile)  // Single file
                    {
                        // file paths
                        string savePath = Server.MapPath("/App_Data/Data/ParlamentMembers.txt");
                        string fileName = Server.HtmlEncode(FileUpload2.FileName);
                        string extension = Path.GetExtension(fileName);

                        FileUpload2.SaveAs(savePath);

                        ErrorLabel.Visible = true;
                        ErrorLabel.ForeColor = Color.Green;
                        ErrorLabel.Text = "Duomenys sėkmingai įrašyti";
                    }
                    else
                    {
                        ErrorLabel.Visible = true;
                        ErrorLabel.ForeColor = Color.Red;
                        ErrorLabel.Text = "Duomenų nepavyko išsaugoti. Nepasirinkti seimo narių dokumentai";
                    }

                }
                else
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.ForeColor = Color.Red;
                    ErrorLabel.Text = "Duomenų nepavyko išsaugoti. Nepasirinkti priėmimų dokumentai";
                }
                //Button2.Enabled = true; //For demonstration purposes disabled
            }
            catch (Exception ex)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = ex.Message;
                //Button2.Enabled = false; //For demonstation purposes disabled
            }



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            // Consultation table data
            Label3.Visible = true; Table1.Visible = true;

            // Parlament members table data
            Label4.Visible = true; Table2.Visible = true;

            // Parlament members calculated table data
            Label5.Visible = true; Table3.Visible = true;

            // File paths
            string pathMultiple = Server.MapPath("/App_Data/Data/InFiles/");
            string path = Server.MapPath("/App_Data/Data/ParlamentMembers.txt");
            string results = Server.MapPath("/App_Data/Results/");

            // Get data from server
            List<List<Consultation>> AllConsultations = InOutUtils.GetConsultationsDir(pathMultiple);
            List<ParlamentMember> ParlamentMembers = InOutUtils.GetParlamentMembers(path);

            for (int i = 0; i < AllConsultations.Count; i++) // All consultations
            {
                List<Consultation> consultations = AllConsultations[i];

                string dirConsult = string.Format("{0}ConsultationDay-dump{1}.txt", results, i);

                InOutUtils.WriteConsultationsToTxtFile(dirConsult, consultations);
            }
            string dirParlament = string.Format("{0}ParlamentMembers.txt", results);
            InOutUtils.WriteParlamentMemberToTxtFile(dirParlament, ParlamentMembers);

            // Web view tables of original data
            foreach (var consultation in AllConsultations)
            {
                Table1.Rows.Add(InOutUtils.MakeRow("Data: " + consultation.First().Date.ToString("yyyy-MM-dd")));

                Table1.Rows.Add(InOutUtils.MakeRow(consultation.First().GetDataNames()));
                foreach (var consultationSingle in consultation)
                {
                    Table1.Rows.Add(InOutUtils.MakeRow(consultationSingle.ToStringArray()));
                }

            }

            Table2.Rows.Add(InOutUtils.MakeRow(ParlamentMembers.First().GetDataNames()));
            foreach (var parlamentMember in ParlamentMembers)
            {
                Table2.Rows.Add(InOutUtils.MakeRow(parlamentMember.ToStringArray()));
            }


            // Calculate:
            // Average one consultation time
            // Average ammount of consultations per day

            List<Consultation> consultationsFlat = AllConsultations.SelectMany(x => x).ToList();

            var consultationsData = consultationsFlat.Join(ParlamentMembers,
                consultation => consultation.Date,
                parlamentMember => parlamentMember.Date,
                (consultation, parlamentMember) => new
                {

                    MemberSurname = parlamentMember.Surname,
                    MemberName = parlamentMember.Name,
                    MemberStart = parlamentMember.OnCallStart,
                    MemberEnd = parlamentMember.OnCallEnd,
                    ConsultationStart = consultation.ArrivalTime,
                    ConsultationEnd = consultation.ArrivalTime.Add(consultation.ConsultationTime.TimeOfDay),
                    ConsultationTime = consultation.ConsultationTime
                }).ToList();

            // Remove items not in member range
            consultationsData.RemoveAll(elem => elem.ConsultationEnd > elem.MemberEnd || elem.ConsultationStart < elem.MemberStart);

            var membersData = consultationsData.GroupBy(
                member => member.MemberSurname + " " + member.MemberName,
                member => member.ConsultationTime,
                (fullname, consultTime) => new
                {
                    Surname = fullname.Split(' ')[0],
                    Name = fullname.Split(' ')[1],
                    ConsultationTime = TimeSpan.FromMinutes(consultTime.Average(t => t.Hour * 60 + t.Minute)),
                    Count = consultTime.Count()
                });

            // Sort list
            membersData = membersData.OrderBy(sortTime => sortTime.ConsultationTime).ThenBy(sortCount => sortCount.Count);

            // Print calculated data to web view table
            List<string> header = new List<string>()
            {
                "Pavardė",
                "Vardas",
                "Vidutinė konsultacijos trukmė",
                "Apsilankiusiųjų skaičius"
            };

            Table3.Rows.Add(InOutUtils.MakeRow(header));
            foreach (var memberData in membersData)
            {
                Table3.Rows.Add(InOutUtils.MakeRow(memberData.Surname, memberData.Name, memberData.ConsultationTime.ToString(@"hh\:mm"), memberData.Count.ToString()));
            }
        }
    }
}
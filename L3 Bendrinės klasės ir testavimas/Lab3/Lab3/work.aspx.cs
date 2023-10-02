using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

using Lab3.Classes;

namespace Lab3
{
    public partial class work : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                string path1 = Server.MapPath("App_Data/U22a.txt");
                string path2 = Server.MapPath("App_Data/U22b.txt");

                string fileName1 = Server.HtmlEncode(FileUpload1.FileName);
                string extension1 = Path.GetExtension(fileName1);

                string fileName2 = Server.HtmlEncode(FileUpload2.FileName);
                string extension2 = Path.GetExtension(fileName2);

                // Check if uploaded files are correct type
                if (extension1.Equals(".txt") && extension2.Equals(".txt"))
                {
                    // Save files to server
                    FileUpload1.SaveAs(path1);
                    FileUpload2.SaveAs(path2);

                    // Show Success
                    Label6.ForeColor = Color.Green;
                    Label6.Text = "Duomenys sėkmingai išsaugoti";
                    
                    LinkList<Project> ProjectData = InOut.ReadProjectFile(path1);
                    LinkList<Student> StudentsData = InOut.ReadStudentFile(path2);

                    // Path of files to dump data to
                    string pathToDumpProject = Server.MapPath("App_Data/ProjectsDump.txt");
                    string pathToDumpStudents = Server.MapPath("App_Data/StudentsDump.txt");

                    // Dump data to files
                    InOut.DumpProjectFile(pathToDumpProject, ProjectData);
                    InOut.DumpStudentFile(pathToDumpStudents, StudentsData);



                    string Proffesor = "";
                    if (!string.IsNullOrEmpty(TextBox1.Text))
                    {
                        Proffesor = TextBox1.Text;
                    }

                    // Table1
                    Label5.Visible = true;
                    Table1.Visible = true;

                    Table1.Rows.Add(DataOutput.MakeRow("<b>Pavardė</b>", "<b>Vardas</b>"));
                    List<string> ActiveProjects = TaskUtils.FindAllActiveProjects(StudentsData);
                    List<string> InactiveProjects = TaskUtils.FindInactiveProjects(ProjectData, ActiveProjects);
                    LinkList<Project> ActiveProffessors = TaskUtils.GetAllActiveProffesors(ProjectData, InactiveProjects);

                    foreach (Project prof in ActiveProffessors)
                    {
                        Table1.Rows.Add(DataOutput.MakeRow(prof.ProfSurname, prof.ProfName));
                    }

                    // Most Projects
                    Label7.Visible = true;
                    Label8.Visible = true;
                    string mostProjects = TaskUtils.MostProjects(ProjectData);
                    Label8.Text = mostProjects;

                    // Table2
                    Label4.Visible = true;
                    Table2.Visible = true;

                    Table2.Rows.Add(DataOutput.MakeRow("<b>Projekto pavadinimas</b>"));
                    List<string> SelectedProffesorProjects = TaskUtils.GetProjectsByProffesor(Proffesor, ProjectData);
                    foreach (string project in SelectedProffesorProjects)
                    {
                        Table2.Rows.Add(DataOutput.MakeRow(project));
                    }

                }
                else
                {
                    Label6.ForeColor = Color.Red;
                    Label6.Text = "Duomenų nepavyko išsaugoti. Neteisingas failo tipas";
                }
            }
            else
            {
                Label6.ForeColor = Color.Red;
                Label6.Text = "Duomenų nepavyko išsaugoti. Nepasirinktas failas";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Classes
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds all active projects
        /// </summary>
        /// <param name="Students">List of all student objects</param>
        /// <returns>List of all active projects</returns>
        public static List<string> FindAllActiveProjects(StudentLinkedList Students)
        {
            List<string> Projects = new List<string>();

            var currentNode = Students.Head;
            while (currentNode != null)
            {
                Student student = currentNode.data as Student;
                if (!Projects.Contains(student.ProjectName))
                {
                    Projects.Add(student.ProjectName);
                }

                currentNode = currentNode.next; // Itterate while
            }

            return Projects;
        }

        /// <summary>
        /// Finds all inactive projects
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <param name="ActiveProjects">List of all active projects</param>
        /// <returns>List of all inactive projects</returns>
        public static List<string> FindInactiveProjects(ProjectLinkedList Projects, List<string> ActiveProjects)
        {
            List<string> projects = new List<string>();

            var currentNode = Projects.Head;
            while (currentNode != null)
            {
                Project project = currentNode.data as Project;
                if (!ActiveProjects.Contains(project.Name))
                {
                    projects.Add(project.Name);
                }

                currentNode = currentNode.next; // Itterate while
            }

            return projects;
        }

        /// <summary>
        /// Gets all active proffesors
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <param name="InactiveProjects">List of all inactive projects</param>
        /// <returns></returns>
        public static ProjectLinkedList GetAllActiveProffesors(ProjectLinkedList Projects, List<string> InactiveProjects)
        {
            ProjectLinkedList Proffesors = new ProjectLinkedList();
            List<string> proffName = new List<string>();

            var currentNode = Projects.Head;
            while(currentNode != null)
            {
                Project project = currentNode.data as Project;
                string tempProffesor = String.Format("{0} {1}", project.ProfSurname, project.ProfName);

                if (!InactiveProjects.Contains(project.Name) && !proffName.Contains(tempProffesor))
                {
                    proffName.Add(tempProffesor);
                    Proffesors.AddSorted(project);
                }

                currentNode = currentNode.next; // Itterate while
            }

            return Proffesors;
        }

        /// <summary>
        /// Finds the proffesor with most projects
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <returns>Returns the proffesors name</returns>
        public static string MostProjects(ProjectLinkedList Projects)
        {
            string Proffesor = "";
            int count = -1;

            var firstNode = Projects.Head;
            while (firstNode != null)
            {
                string tempProffesor;
                int tempcount = 0;

                Project project_temp = firstNode.data as Project;
                tempProffesor = String.Format("{0} {1}", project_temp.ProfSurname, project_temp.ProfName);

                var secondNode = Projects.Head;
                while (secondNode != null)
                {
                    Project project_secondtemp = secondNode.data as Project;
                    string secondProffesor = String.Format("{0} {1}", project_secondtemp.ProfSurname, project_secondtemp.ProfName);
                    if (tempProffesor == secondProffesor)
                    {
                        tempcount++;
                    }

                    secondNode = secondNode.next; // Itterate child while
                }

                //Change to new proffesor if tempProffesor has more projects
                if (count < tempcount)
                {
                    Proffesor = tempProffesor;
                    count = tempcount;
                }

                firstNode = firstNode.next; // Itterate parent while
            }

            return Proffesor;
        }
        /// <summary>
        /// Gets all project names by <paramref name="proffesor"/> name and surname
        /// </summary>
        /// <param name="proffesor">Proffesor surname and name</param>
        /// <param name="Projects">List of all projects</param>
        /// <returns></returns>
        public static List<string> GetProjectsByProffesor(string proffesor, ProjectLinkedList Projects)
        {
            string[] profSplit = proffesor.Split(' ');
            string proffSurname = profSplit[0];
            string proffName = profSplit[1];

            List<string> ProjectNames = new List<string>();

            var currentNode = Projects.Head;
            while (currentNode != null)
            {
                Project project = currentNode.data as Project;
                if (project.ProfName == proffName && project.ProfSurname == proffSurname)
                {
                    ProjectNames.Add(project.Name);
                }

                currentNode = currentNode.next; // Itterate while
            }

            return ProjectNames;
        }
    }
}
using Lab3.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.Tests
{
    [TestClass()]
    public class TaskUtilsTests
    {
        [TestMethod()]
        public void FindAllActiveProjects_HasActiveProjects_AllActiveProjects()
        {
            // Arrange
            var list = new LinkList<Student>();
            list.Add(new Student("Rekursija", "Pavardenis", "Vardenis", "IFF/1-1"));
            list.Add(new Student("Susietasis sąrašas", "Pavardaitė", "Vardaitė", "IFF/1-1"));
            list.Add(new Student("Polimorfizmas", "Jonas", "Jonaitis", "IFF/1-2"));
            list.Add(new Student("Deklraratyvusis programavimas", "Arnas", "Šablinskas", "IFF/1-1"));
            list.Add(new Student("Rekursija", "Domantas", "Vaičiulis", "IFF/1-3"));
            list.Add(new Student("Susietasis sąrašas", "Donatas", "Kušleika", "IFF/1-4"));
            list.Add(new Student("Lambda išraiškų taikymas", "Gabija", "Grinkevičiūtė", "IFF/1-5"));

            List<string> AllActiveProjects_Correct = new List<string>
            {
                "Rekursija",
                "Susietasis sąrašas",
                "Polimorfizmas",
                "Deklraratyvusis programavimas",
                "Lambda išraiškų taikymas"
            };


            // Act

            List<string> AllActiveProjects = TaskUtils.FindAllActiveProjects(list);

            // Assert

            Assert.IsTrue(AllActiveProjects.SequenceEqual(AllActiveProjects_Correct));
        }

        [TestMethod()]
        public void FindAllActiveProjects_EmptyList_EmptyReturnList()
        {
            // Arrange
            var list = new LinkList<Student>();

            // Act
            List<string> AllActiveProjects = TaskUtils.FindAllActiveProjects(list);

            // Assert

            Assert.IsTrue(AllActiveProjects.Count == 0);
        }

        [TestMethod()]
        public void FindInactiveProjects_NoInactiveProjects_EmptyReturnList()
        {
            // Arrange
            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklaratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));

            List<string> AllActiveProjects = new List<string>
            {
                "Lambda išraiškų taikymas",
                "Susietasis sąrašas",
                "Rekursija",
                "Deklraratyvusis programavimas",
                "Polimorfizmas"
            };

            List<string> AllInactiveProjects_Correct = new List<string>();

            // Act

            List<string> AllInactiveProjects = new List<string>();

            AllActiveProjects = TaskUtils.FindInactiveProjects(list, AllActiveProjects);

            // Assert

            Assert.IsTrue(AllInactiveProjects.SequenceEqual(AllInactiveProjects_Correct));

        }

        [TestMethod()]
        public void FindInactiveProjects_HasInactiveProjects_ReturnsAllInactiveProjects()
        {
            // Arrange

            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            List<string> AllActiveProjects = new List<string>
            {
                "Lambda išraiškų taikymas",
                "Susietasis sąrašas",
                "Rekursija",
                "Deklraratyvusis programavimas",
                "Polimorfizmas"
            };

            List<string> AllInactiveProjects_Correct = new List<string>
            {
                "Užklausos LINQ"
            };

            // Act

            List<string> AllInactiveProjects = new List<string>();

            AllInactiveProjects = TaskUtils.FindInactiveProjects(list, AllActiveProjects);

            // Assert

            Assert.IsTrue(AllInactiveProjects.SequenceEqual(AllInactiveProjects_Correct));

        }

        [TestMethod()]
        public void GetAllActiveProffesors_NoActiveProffesors_ReturnemptyList()
        {
            // Arrange

            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            List<string> InactiveProjects = new List<string>
            {
                "Lambda išraiškų taikymas",
                "Susietasis sąrašas",
                "Rekursija",
                "Deklraratyvusis programavimas",
                "Polimorfizmas",
                "Užklausos LINQ"
            };

            LinkList<Project> AllActiveProffesors_Correct = new LinkList<Project>();



            // Act

            LinkList<Project> AllActiveProffesors = new LinkList<Project>();

            AllActiveProffesors = TaskUtils.GetAllActiveProffesors(list, InactiveProjects);

            // Assert
            List<string> ProffesorsString_Correct = new List<string>();
            foreach (Project project in AllActiveProffesors_Correct)
            {
                ProffesorsString_Correct.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            List<string> ProffesorsString = new List<string>();
            foreach (Project project in AllActiveProffesors)
            {
                ProffesorsString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            Assert.IsTrue(ProffesorsString_Correct.SequenceEqual(ProffesorsString));
        }

        [TestMethod()]
        public void GetAllActiveProffesors_HasActiveProffesors_ReturnActiveProfList()
        {
            // Arrange

            LinkList<Project> list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            List<string> InactiveProjects = new List<string>
            {
                "Lambda išraiškų taikymas",
                "Susietasis sąrašas",
                "Rekursija",
                "Deklraratyvusis programavimas"
            };


            LinkList<Project> AllActiveProffesors_Correct = new LinkList<Project>();
            AllActiveProffesors_Correct.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            AllActiveProffesors_Correct.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));



            // Act

            LinkList<Project> AllActiveProffesors = new LinkList<Project>();

            AllActiveProffesors = TaskUtils.GetAllActiveProffesors(list, InactiveProjects);

            // Assert
            List<string> ProffesorsString_Correct = new List<string>();
            foreach (Project project in AllActiveProffesors_Correct)
            {
                ProffesorsString_Correct.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            List<string> ProffesorsString = new List<string>();
            foreach (Project project in AllActiveProffesors)
            {
                ProffesorsString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            Assert.IsTrue(ProffesorsString_Correct.SequenceEqual(ProffesorsString));
        }

        [TestMethod()]
        public void MostProjects_OneProffesorWithMostProjects_ReturnMostProjectsProffesor()
        {
            // Arrange
            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Jusas", "Vacius", 23));

            string MostProjectsProffesor_Correct = "Jusas Vacius";

            // Act

            string MostProjectsProffesor = TaskUtils.MostProjects(list);

            // Assert

            Assert.AreEqual(MostProjectsProffesor_Correct, MostProjectsProffesor);
        }

        [TestMethod()]
        public void MostProjects_AllEqualAmmountOfProjects_ReturnFirstProffesor()
        {
            // Arrange
            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            string MostProjectsProffesor_Correct = "Jusas Vacius";

            // Act
            string MostProjectsProffesor = TaskUtils.MostProjects(list);

            // Assert

            Assert.AreEqual(MostProjectsProffesor_Correct, MostProjectsProffesor);

        }

        [TestMethod()]
        public void GetProjectsByProffesor_ProffesorInList_ReturnsAllProjectsByProffesor()
        {
            // Arrange
            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            string proffesor = "Jusas Vacius";

            List<string> ProjectsByProffesor_Correct = new List<string>
            {
                "Rekursija",
                "Lambda išraiškų taikymas"
            };


            // Act

            List<string> ProjectsByProffesor = TaskUtils.GetProjectsByProffesor(proffesor, list);

            // Assert

            Assert.IsTrue(ProjectsByProffesor_Correct.SequenceEqual(ProjectsByProffesor));
        }

        [TestMethod()]
        public void GetProjectsByProffesor_ProffesorNotInList_ReturnsEmptyList()
        {
            // Arrange
            var list = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklraratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            list.Add(new Project("Lambda išraiškų taikymas", "Jusas", "Vacius", 24));
            list.Add(new Project("Užklausos LINQ", "Nabutaitė", "Lina", 23));

            string proffesor = "Guogis Evaldas";

            List<string> ProjectsByProffesor_Correct = new List<string>();

            // Act

            List<string> ProjectsByProffesor = TaskUtils.GetProjectsByProffesor(proffesor, list);

            // Assert

            Assert.IsTrue(ProjectsByProffesor_Correct.SequenceEqual(ProjectsByProffesor));
        }
    }


}